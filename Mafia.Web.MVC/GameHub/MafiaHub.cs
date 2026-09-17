using System.Collections.Concurrent;
using Enum.Enums;
using Manager.ServiceManager.Game.GameEngine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models.DefaultModels;
using Service.Common.Lobby;
using Service.Common.ServiceInjector.Game;

namespace Mafia.Web.MVC.GameHub;

/// <summary>
/// Хаб для общения с пользователем в реальном времени
/// </summary>
[Authorize]
public class MafiaHub : Hub
{
    private readonly ILobbyService _lobby;
    private readonly IGameService _game;
    private readonly AppLogger _logger;
    
    public MafiaHub(ILobbyService lobby, IGameService game, ILoggerFactory loggerFactory)
    {
        _lobby = lobby;
        _game = game;
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

        var can = _lobby.CheckIfCanCreateGame(lobbyName, userId);
        if (can.IsError)
            return new ExecuteResult
                { State = can.State, Message = can.Message, MessageCode = can.MessageCode };
        
        return _game.CreateGame(lobbyName, userId);
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