using Microsoft.EntityFrameworkCore;
using StageLabApi.Data;
using StageLabApi.Interfaces;
using StageLabApi.Services;

namespace StageLabApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IRoleActionsCacheService, RoleActionsCacheService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(config["DefaultConnection"])
        );

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = config["Redis:ConnectionString"];
            options.InstanceName = "StageLabApi";
        });

        return services;
    }
}
