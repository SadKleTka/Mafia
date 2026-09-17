using Manager.ServiceManager.ActiveGame;
using Manager.ServiceManager.States.GameDay;

namespace Manager.ServiceManager.Game.GameEngine;

public class GameEngine
{
    private readonly ActiveGameCache _cache;
    private readonly GameDay _day;

    public GameEngine(ActiveGameCache cache, GameDay day)
    {
        _cache = cache;
        _day = day;
    }

    public void MovePhase()
    {
        _day.MovePhase();
    }

    public GameDay GetDayState()
    {
        return _day;
    }

    public void CreateGame(string lobbyName)
    {
        
    }
    
    
    
    
}