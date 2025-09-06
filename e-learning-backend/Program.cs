using System.Security.Claims;
using System.Text;
using e_learning_backend.Infrastructure.Api.Services;
using e_learning_backend.Infrastructure.Configuration;
using e_learning_backend.Infrastructure.Configuration.Impl;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using e_learning_backend.Infrastructure.Persistence.Services;
using e_learning_backend.Infrastructure.Security.Impl;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using e_learning_backend.Infrastructure.Security.Impl.Services;
using e_learning_backend.Infrastructure.Transformers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ITeacherRepository = e_learning_backend.Infrastructure.Persistence.Repositories.ITeacherRepository;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

// --------------------------------------------------------------------------------------------------------
// DBCONTEXTS AND CONTROLLERS REGISTRATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new LowercaseRouteTransformer()));
});

// --------------------------------------------------------------------------------------------------------
// CORS CONFIGURATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
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

// Add Swagger with bearer‐token support
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
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// --------------------------------------------------------------------------------------------------------
// "BEANS" CONFIGURATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddSingleton<IJsonConfigurationProvider, JsonConfigurationProvider>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentsRepository, StudnetsRepository>();


builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ITeacherService, TeachersService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();

// --------------------------------------------------------------------------------------------------------
// WEB APPLICATION CONFIGURATION: MIDDLEWARES, ROUTING, AUTHORIZATION, EXCEPTION HANDLING, ETC.
// --------------------------------------------------------------------------------------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var webRoot = builder.Environment.WebRootPath;
if (string.IsNullOrEmpty(webRoot))
{
    webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
}


if (!Directory.Exists(webRoot))
{
    Directory.CreateDirectory(webRoot);
}

var uploadsPath = Path.Combine(webRoot, "uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();