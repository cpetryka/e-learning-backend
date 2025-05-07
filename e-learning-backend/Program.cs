using System.Security.Claims;
using System.Text;
using e_learning_backend.Infrastructure.Configuration;
using e_learning_backend.Infrastructure.Configuration.Impl;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using e_learning_backend.Infrastructure.Persistence.Services;
using e_learning_backend.Infrastructure.Security.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

// --------------------------------------------------------------------------------------------------------
// DBCONTEXTS AND CONTROLLERSREGISTRATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<CoursesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();

// --------------------------------------------------------------------------------------------------------
// SECURITY CONFIGURATION
// --------------------------------------------------------------------------------------------------------
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken            = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey         = new SymmetricSecurityKey(
                                          Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer           = false,
            ValidateAudience         = false,

            // Tell ASP.NET “look for ClaimTypes.Role” when evaluating [Authorize(Roles=...)]
            RoleClaimType            = ClaimTypes.Role,
            NameClaimType            = ClaimTypes.NameIdentifier
        };

        // After the JWT is validated, go to the DB and load _all_ roles for this user,
        // then add them as ClaimTypes.Role so policies will work.
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
    options.AddPolicy("all",   p => p.RequireRole("admin", "user", "student", "spectator"));
    options.AddPolicy("admin", p => p.RequireRole("admin"));
    options.AddPolicy("teacher",  p => p.RequireRole("teacher"));
    options.AddPolicy("student",  p => p.RequireRole("student"));
    options.AddPolicy("spectator",  p => p.RequireRole("spectator"));
});

// Add Swagger with bearer‐token support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-LEARNING", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In          = ParameterLocation.Header,
        Description = "Enter JWT token",
        Name        = "Authorization",
        Type        = SecuritySchemeType.ApiKey,
        BearerFormat= "JWT",
        Scheme      = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "Bearer"
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
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<ISecurityService, SecurityService>();

// --------------------------------------------------------------------------------------------------------
// WEB APPLICATION CONFIGURATION: MIDDLEWARES, ROUTING, AUTHORIZATION, EXCEPTION HANDLING, ETC.
// --------------------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();