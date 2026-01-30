using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Jobs;
using Microsoft.IdentityModel.Tokens;
using StageLabApi.Extensions;
using StageLabApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var jwtKey =
    builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is not configured");

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy =>
        {
            var origins = builder.Configuration["Cors:AllowedOrigins"]?.Split(',') ?? [];
            policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        }
    );
});

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

Bogus.Premium.License.LicenseTo = "StageLab";
Bogus.Premium.License.LicenseKey = builder.Configuration["Bogus:LicenseKey"];

builder.Services.AddHangfire(config =>
    config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UsePostgreSqlStorage(options =>
            options.UseNpgsqlConnection(builder.Configuration["DefaultConnection"])
        )
);

builder.Services.AddHangfireServer();

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard(
    "/hangfire",
    new DashboardOptions { Authorization = new[] { new AllowAllDashboardAuthorizationFilter() } }
);

RecurringJobs.Register(app.Services);

app.MapControllers();

app.Run();
