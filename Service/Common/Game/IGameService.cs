using Models.DefaultModels;

namespace Service.Common.ServiceInjector.Game;

public interface IGameService
{
    ExecuteResult CreateGame(string lobbyName, string userId);
}