using Manager.ServiceManager.ActiveGame;
using Manager.ServiceManager.Game.GameEngine;
using Manager.ServiceManager.Lobby;
using Manager.ServiceManager.States.GameDay;
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
        services.AddSingleton<ActiveGameCache>();
        services.AddSingleton<GameEngine>();
        services.AddSingleton<GameDay>();
        return services;
    }
}