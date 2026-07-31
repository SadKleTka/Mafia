using DataManager.DataContract;
using Enum.Enums;
using Manager.ServiceManager.Lobby;
using Microsoft.AspNetCore.SignalR;
using Models.DefaultModels;

namespace Service.Common.Lobby;

/// <summary>
/// Сервис для работы с комнатами
/// </summary>
public class LobbyService : ILobbyService
{
    private readonly LobbyCache _cache;
    private readonly AppDbContext _context;

    public LobbyService(LobbyCache cache, AppDbContext context)
    {
        _cache = cache;
        _context = context;
    }
    /// <summary>
    /// Присоединиться к лобби
    /// </summary>
    /// <param name="lobbyName">Название комнаты</param>
    /// <param name="connectionId">Номер соединения</param>
    /// <param name="userId">Номер пользователя</param>
    public async Task<ExecuteResult> JoinLobby(string lobbyName, string connectionId, string userId)
    {
        if (string.IsNullOrEmpty(lobbyName) || string.IsNullOrEmpty(connectionId) || string.IsNullOrEmpty(userId))
            return new ExecuteResult { State = ExecuteState.Error, Message = "Поля не могут быть пустыми", MessageCode = "409" };

        var newLobby = new DomainModel.Models.Entity.Lobby
        {
            Name = lobbyName,
        };

        var result = _cache.JoinToLobby(lobbyName, connectionId, userId);
        if (!result.IsOK)
            return result;
        
        _context.Lobbies.Add(newLobby);
        await _context.SaveChangesAsync();

        return result;
    }

    /// <summary>
    /// Выйти из лобби
    /// </summary>
    /// <param name="lobbyName">Название комнаты</param>
    /// <param name="connectionId">Номер соединения</param>
    /// <param name="userId">Номер пользователя</param>
    /// <returns></returns>
    public async Task<ExecuteResult> LeaveLobby(string lobbyName, string connectionId, string userId)
    {
        return new ExecuteResult
        {
            State = ExecuteState.OK,
            Message = "заглушка",
            MessageCode = "200"
        };
    }
}