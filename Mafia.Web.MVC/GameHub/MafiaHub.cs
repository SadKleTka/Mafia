using System.Collections.Concurrent;
using Enum.Enums;
using Manager.ServiceManager.Game.GameEngine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models.DefaultModels;
using Service.Common.Lobby;

namespace Mafia.Web.MVC.GameHub;

/// <summary>
/// Хаб для общения с пользователем в реальном времени
/// </summary>
[Authorize]
public class MafiaHub : Hub
{
    private readonly ConcurrentDictionary<string, GameEngine> _activeGames = new();
    private readonly ILobbyService _lobby;
    private readonly AppLogger _logger;
    
    public MafiaHub(ILobbyService lobby, ILoggerFactory loggerFactory)
    {
        _lobby = lobby;
        var baseLogger = loggerFactory.CreateLogger(GetType());
        _logger = new AppLogger(baseLogger);
    }
    
    public IReadOnlyDictionary<string, List<string>> GetActiveLobbies()
    {
        return _lobby.GetCachedUsers();
    }

    public ExecuteResult CreateGame(string lobbyName)
    {
        var userId = Context.UserIdentifier;
        
        if (_activeGames.ContainsKey(lobbyName))
            return new ExecuteResult
                { State = ExecuteState.Error, Message = "Данная игра уже запущена", MessageCode = "404" };

        var result = _lobby.CheckIfCanCreateGame(lobbyName, userId);
        
        if (result.IsError)
            return new ExecuteResult
                { State = result.State, Message = result.Message, MessageCode = result.MessageCode };
        
        if (_activeGames.TryAdd(lobbyName, _lobby.CreateGameEngine()))
        {
            return new ExecuteResult
                { State = ExecuteState.OK, Message = "Игра успешно создана", MessageCode = "200" };
        }
        
        return new ExecuteResult
            { State = ExecuteState.Error, Message = "Не удалось запустить игру, попробуйте снова", MessageCode = "409" };
    }

    /// <summary>
    /// Присоединиться к лобби
    /// </summary>
    /// <param name="lobbyName">Название лобби</param>
    /// <returns></returns>
    public async Task<ExecuteResult> JoinLobby(string lobbyName)
    {
        var connectionId = Context.ConnectionId;
        var userId = Context.UserIdentifier;
        
        if (_activeGames.ContainsKey(lobbyName))
            return new ExecuteResult
                { State = ExecuteState.Error, Message = "Данная игра уже запущена", MessageCode = "404" };
        
        var result = await _lobby.JoinLobby(lobbyName, connectionId, userId);

        if (result.IsOK || result.IsCreated)
        {
            await Groups.AddToGroupAsync(connectionId, lobbyName);
        }
        _logger.Log("Вызван сервис присоединения к лобби", result.State);
        return result;
    }

    /// <summary>
    /// Выход из лобби
    /// </summary>
    /// <param name="lobbyName"></param>
    /// <returns></returns>
    public async Task<ExecuteResult> LeaveLobby(string lobbyName)
    {
        var connectionId = Context.ConnectionId;
        var userId = Context.UserIdentifier;

        var result = await _lobby.LeaveLobby(lobbyName, connectionId, userId);

        if (result.IsOK || result.IsDeleted)
        {
            await Groups.RemoveFromGroupAsync(connectionId, lobbyName);
        }
        _logger.Log("Вызван сервис выхода из лобби", result.State);
        return result;
    }
    
}