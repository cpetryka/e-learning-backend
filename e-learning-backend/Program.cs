using System.Security.Claims;
using System.Text;
using e_learning_backend.Application.Files;
using e_learning_backend.Application.Files.Validation;
using e_learning_backend.Application.Files.Validation.Interfaces;
using e_learning_backend.Application.Services;
using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.FileStorage;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl.Interfaces;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl.Users;
using e_learning_backend.Infrastructure.Persistence.Services;
using e_learning_backend.Infrastructure.Security.Impl;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using e_learning_backend.Infrastructure.Transformers;
using E_Learning.Domain.Common.Interfaces;
using E_Learning.Infrastructure.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ITeacherRepository = e_learning_backend.Infrastructure.Persistence.Repositories.ITeacherRepository;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var lokiUrl = builder.Configuration["GrafanaLoki:Url"];
var loggerConfig = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console();

if (!string.IsNullOrEmpty(lokiUrl))
{
    loggerConfig.WriteTo.GrafanaLoki(
        lokiUrl,
        labels: new[] { new LokiLabel { Key = "app", Value = "e-learning-backend" } }
    );
}

Log.Logger = loggerConfig.CreateLogger();

builder.Host.UseSerilog();
// --------------------------------------------------------------------------------------------------------
// DBCONTEXTS AND CONTROLLERS REGISTRATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new LowercaseRouteTransformer()));
});


builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationContext>((sp, options) =>
{
    var logger = sp.GetRequiredService<ILogger<SlowQueryInterceptor>>();
    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
        .AddInterceptors(new SlowQueryInterceptor(logger, httpContextAccessor));
});

// --------------------------------------------------------------------------------------------------------
// CORS CONFIGURATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        var allowedOrigins = new List<string>
        {
            "http://localhost:5175",
            "http://localhost:5173"
        };
        
        var publicIp = builder.Configuration["PublicIp"];
        if (!string.IsNullOrEmpty(publicIp))
        {
            allowedOrigins.Add($"http://{publicIp}:5173");
            allowedOrigins.Add($"http://{publicIp}:5175");
        }
        
        policy.WithOrigins(allowedOrigins.ToArray())
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// --------------------------------------------------------------------------------------------------------
// SECURITY CONFIGURATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.NameIdentifier
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async ctx =>
            {
                var userId = ctx.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    ctx.Fail("No sub/NameIdentifier claim.");
                    return;
                }

                var svc = ctx.HttpContext.RequestServices.GetRequiredService<IUsersRepository>();
                var user = await svc.GetByIdAsync(Guid.Parse(userId));
                if (user == null)
                {
                    ctx.Fail("User not found.");
                    return;
                }

                var identity = ctx?.Principal?.Identity as ClaimsIdentity;
                foreach (var role in user.Roles)
                {
                    identity!.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
                }
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("all", p => p.RequireRole("admin", "user", "student", "spectator"));
    options.AddPolicy("admin", p => p.RequireRole("admin"));
    options.AddPolicy("teacher", p => p.RequireRole("teacher"));
    options.AddPolicy("student", p => p.RequireRole("student"));
    options.AddPolicy("spectator", p => p.RequireRole("spectator"));
});

// Swagger + bearer
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-LEARNING", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// --------------------------------------------------------------------------------------------------------
// FILE SERVER ROOTS 
// --------------------------------------------------------------------------------------------------------
var webRoot = builder.Environment.WebRootPath;
if (string.IsNullOrEmpty(webRoot))
{
    webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
}

Directory.CreateDirectory(webRoot);

var uploadsPath = Path.Combine(webRoot, "uploads");
Directory.CreateDirectory(uploadsPath);

// --------------------------------------------------------------------------------------------------------
// "BEANS" CONFIGURATION (DI)
// --------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentsRepository, StudnetsRepository>();
builder.Services.AddScoped<IParticipationRepository, ParticipationRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ISpectatorsRepository, SpectatorsRepository>();
builder.Services.AddScoped<IFileResourceRepository, FileResourceRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<ILinkResourcesRepository, LinkResourcesRepository>();
builder.Services.AddScoped<ICourseVariantRepository, CourseVariantRepository>();


builder.Services.AddScoped<ISpectatorsService, SpectatorsService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ITeacherService, TeachersService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IClassesService, ClassesService>();
builder.Services.AddScoped<ITagsService, TagsService>();
builder.Services.AddScoped<IQuizzesService, QuizzesService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IUsersFilesService, UsersFilesService>();

builder.Services.AddSingleton<IEmailTemplateService, EmailTemplateService>();
builder.Services.AddScoped<ISpectatorInviteRepository, SpectatorInviteRepository>();
builder.Services.AddScoped<ISpectatorInviteService, SpectatorInviteService>();

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddScoped<SlowQueryInterceptor>();

// Pliki: storage + walidator rozszerzeń
builder.Services.AddSingleton<IFileStorage, LocalDiskFileStorage>();
builder.Services.AddSingleton<IFileExtensionValidator.IAssignmentExtensionValidator, AssignmentExtensionValidator>();
builder.Services.AddSingleton<IFileExtensionValidator.IProfilePictureExtensionValidator, ProfilePictureValidator>();




// EMAIL CONFIGURATION
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));

// --------------------------------------------------------------------------------------------------------
//  FILE UPLOAD CONFIGURATION
// --------------------------------------------------------------------------------------------------------
builder.Services.Configure<FileUploadOptions>(builder.Configuration.GetSection("FileUpload"));
builder.Services.PostConfigure<FileUploadOptions>(opts => opts.RootPath = uploadsPath);

// --------------------------------------------------------------------------------------------------------
// BUILD
// --------------------------------------------------------------------------------------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --------------------------------------------------------------------------------------------------------
// STATIC FILES: /uploads -> wwwroot/uploads
// --------------------------------------------------------------------------------------------------------
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});


// --------------------------------------------------------------------------------------------------------
// PIPELINE
// --------------------------------------------------------------------------------------------------------
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();