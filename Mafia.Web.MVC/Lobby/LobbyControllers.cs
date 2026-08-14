using Enum.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Lobby;

namespace Mafia.Web.MVC.Lobby;

[ApiController]
[Route("[controller]")]
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
        if (!allLobbies.Any())
        {
            _logger.Log("Лобби отсутствуют", ExecuteState.OK);
            return JsonContent(new
            {
                state = true,
                message = "Лобби отсутствуют",
                lobbies =  allLobbies
            });
        }
        _logger.Log( "Лобби найдены", ExecuteState.OK);
        return JsonContent(new
        {
            state = true,
            message = "Лобби найдены",
            lobbies = allLobbies
        });
    }
}