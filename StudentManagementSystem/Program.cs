using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using StudentManagementSystem.Data;
using StudentManagementSystem.Middleware;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.Services;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();



// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection")));



// Dependency Injection
builder.Services.AddScoped<IStudentRepository,
    StudentRepository>();

builder.Services.AddScoped<IStudentService,
    StudentService>();



// JWT Authentication
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)

    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]))
            };
    });



// Controllers
builder.Services.AddControllers();



// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StudentManagementSystem",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter JWT Token"
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
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
                new string[] {}
            }
        });
});

var app = builder.Build();



// Middleware
app.UseMiddleware<ExceptionMiddleware>();



// Swagger
app.UseSwagger();

app.UseSwaggerUI();



// Authentication
app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();

app.Run();