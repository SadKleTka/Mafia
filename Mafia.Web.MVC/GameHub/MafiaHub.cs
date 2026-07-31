using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models.DefaultModels;
using Service.Common.Lobby;

namespace Mafia.Web.MVC.GameHub;

/// <summary>
/// Хаб для общение с пользователем в реальном времени
/// </summary>
[Authorize]
public class MafiaHub : Hub
{
    private readonly ILobbyService _lobby;
    private readonly AppLogger _logger;
    
    public MafiaHub(ILobbyService lobby, AppLogger logger)
    {
        _lobby = lobby;
        _logger = logger;
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

        if (result.IsOK)
        {
            await Groups.AddToGroupAsync(connectionId, lobbyName);
        }
        _logger.Log("Вызван сервис присоединения к лобби", result.State);
        return result;
    }
    
}