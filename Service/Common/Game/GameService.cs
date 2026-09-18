using Enum.Enums;
using Manager.ServiceManager.ActiveGame;
using Manager.ServiceManager.Game.GameEngine;
using Manager.ServiceManager.States.GameDay;
using Models.DefaultModels;

namespace Service.Common.ServiceInjector.Game;

public class GameService : IGameService
{
    private readonly ActiveGameCache _gameCache;

    public GameService(ActiveGameCache gameCache)
    {
        _gameCache = gameCache;
    }
    

    public ExecuteResult CreateGame(string lobbyName, string userId)
    {
        var games = _gameCache.GetActiveGames();
        
        if (games.ContainsKey(lobbyName))
            return new ExecuteResult
                { State = ExecuteState.Error, Message = "Данная игра уже запущена", MessageCode = "404" };
        
        if (_gameCache.TryToAdd(lobbyName, CreateGameEngine()))
        {
            return new ExecuteResult
                { State = ExecuteState.OK, Message = "Игра успешно создана", MessageCode = "200" };
        }
        
        return new ExecuteResult
            { State = ExecuteState.Error, Message = "Не удалось запустить игру, попробуйте снова", MessageCode = "409" };
    }

    private GameEngine CreateGameEngine()
    {
        return new GameEngine(_gameCache, new GameDay());
    }
    
}