using Manager.ServiceManager.Game.GameEngine;
using Microsoft.AspNetCore.SignalR;
using Models.DefaultModels;

namespace Service.Common.Lobby;

public interface ILobbyService
{
    Task<ExecuteResult> JoinLobby(string lobbyName, string connectionId, string userId);
    Task<ExecuteResult> LeaveLobby(string lobbyName, string connectionId, string userId);
    ExecuteResult CheckIfCanCreateGame(string lobbyName, string userId);
    IReadOnlyDictionary<string, List<string>> GetCachedUsers();
}