using System.Collections.Concurrent;
using Enum.Enums;
using Models.DefaultModels;

namespace Manager.ServiceManager.Lobby;

/// <summary>
/// Класс для кэширования лобби
/// </summary>
public class LobbyCache
{ 
    private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _lobbyUsers = new();

    /// <summary>
    /// Кэшировать лобби
    /// </summary>
    /// <param name="lobbyName">Название комнаты</param>
    /// <param name="connectionId">Номер соединения</param>
    /// <param name="userId">Номер пользователя</param>
    /// <returns></returns>
    public ExecuteResult JoinToLobby(string lobbyName, string connectionId, string userId)
    {
        var users = _lobbyUsers.GetOrAdd(lobbyName, _ => new ConcurrentDictionary<string, string>());
        
        if (!users.Values.Contains(userId))
        {
            users.TryAdd(connectionId, userId);
            if (users.Count == 1)
            {
                return new ExecuteResult
                {
                    State = ExecuteState.Created,
                    Message = "Вы успешно создали лобби",
                    MessageCode = "200"
                };
            }
            return new ExecuteResult
            {
                State = ExecuteState.OK,
                Message = "Вы успешно зашли в лобби",
                MessageCode = "200"
            };
        }
        
        return new ExecuteResult
        {
            State = ExecuteState.Error,
            Message = "Вы не смогли подключиться к лобби",
            MessageCode = "500"
        };
    }

    /// <summary>
    /// Удалить кэш после выхода пользователя из лобби
    /// </summary>
    /// <param name="lobbyName">Название комнаты</param>
    /// <param name="connectionId">Номер соединения</param>
    /// <param name="userId">Номер пользователя</param>
    /// <returns></returns>
    public ExecuteResult LeaveFromLobby(string lobbyName, string connectionId, string userId)
    {
        if (_lobbyUsers.TryGetValue(lobbyName, out var users))
        {
            if (users.Values.Contains(userId))
            {
                users.TryRemove(connectionId, out _);
                RemoveLobby(lobbyName);
                return new ExecuteResult
                {
                    State = ExecuteState.OK,
                    Message = "Вы вышли из лобби",
                    MessageCode = "200"
                };
            }
        }
        return new ExecuteResult
        {
            State = ExecuteState.Error,
            Message = "Вы не смогли выйти из лобби",
            MessageCode = "500"
        };
    }

    public void RemoveLobby(string lobbyName)
    {
        if (_lobbyUsers.TryGetValue(lobbyName, out var users))
        {
            if (users.IsEmpty)
            {
                _lobbyUsers.TryRemove(lobbyName, out _);
            }
        }
    }
}