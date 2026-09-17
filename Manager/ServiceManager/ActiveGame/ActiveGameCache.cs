using System.Collections.Concurrent;
using Manager.ServiceManager.Game.GameEngine;

namespace Manager.ServiceManager.ActiveGame;

public class ActiveGameCache
{
    private readonly ConcurrentDictionary<string, GameEngine> _activeGames = new();

    public IReadOnlyDictionary<string, GameEngine> GetActiveGames()
    {
        return _activeGames.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value
        );
    }

    public bool TryToAdd(string lobbyName, GameEngine game)
    {
        return _activeGames.TryAdd(lobbyName, game);
    }
    
}