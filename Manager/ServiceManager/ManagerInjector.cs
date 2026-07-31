using Manager.ServiceManager.Lobby;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.ServiceManager;

/// <summary>
/// Инжектор сервиса в проект
/// </summary>
public static class ManagerInjector
{
    public static IServiceCollection AddManager(this IServiceCollection services)
    {
        services.AddSingleton<LobbyCache>();
        return services;
    }
}