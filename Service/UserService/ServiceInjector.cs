using DataManager.DataContract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Authentication;

namespace UserService;

public static class ServiceInjector
{
    public static IServiceCollection AddTheSystem(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("ConnectionStrings").Get<string>();
        services.AddDataBase(connectionString);
        services.AddAuthenticationModule(configuration);
        
        return services;
    }
}