using DataManager.DataContract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Authentication;
using Service.Common.User;

namespace Service.Common.ServiceInjector;

/// <summary>
/// Инжектор всего сервиса в билд проекта
/// </summary>
public static class ServiceInjector
{
    public static IServiceCollection AddTheSystem(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection");
        services.AddDataBase(connectionString);
        services.AddAuthenticationModule(configuration);

        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}