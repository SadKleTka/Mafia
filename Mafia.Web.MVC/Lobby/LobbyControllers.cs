using Enum.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Lobby;

namespace Mafia.Web.MVC.Lobby;

/// <summary>
/// Контроллер для получения списка лобби
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LobbyControllers : MafiaOnlineController
{

    private readonly ILobbyService _lobbyService;

    public LobbyControllers(ILoggerFactory loggerFactory, ILobbyService lobbyService) : base(loggerFactory)
    {
        _lobbyService = lobbyService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllLobbies()
    {
        var allLobbies = await _lobbyService.GetAllLobbies();
        
        _logger.Log( "Вызван сервис по получению всех лобби", ExecuteState.OK);
        return JsonContent(new
        {
            state = true,
            message = "Лобби выведены",
            lobbies = allLobbies
        });
    }
}