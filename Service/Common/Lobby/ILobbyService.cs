using Models.DefaultModels;
using LobbyEntity = DomainModel.Models.Entity.Lobby;


namespace Service.Common.Lobby;

public interface ILobbyService
{
    Task<ExecuteResult> JoinLobby(string lobbyName, string connectionId, string userId);
    Task<ExecuteResult> LeaveLobby(string lobbyName, string connectionId, string userId);
    IReadOnlyDictionary<string, List<string>> GetCachedUsers();
    
    Task<List<LobbyEntity>> GetAllLobbies();
}