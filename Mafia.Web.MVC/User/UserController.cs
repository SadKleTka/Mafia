using Microsoft.AspNetCore.Mvc;
using Service.UserService.User;

namespace Mafia.Web.MVC.User;

/// <summary>
/// Контроллер для работы с пользователем
/// </summary>
public class UserController : MafiaOnlineController
{
    private readonly IUserService _service;
    private readonly ILogger<UserController> _logger;
    
    public UserController(IUserService service, ILogger<UserController> logger)
    {
        _service = service;
        _logger = logger;
    }

    public async Task<ActionResult> Register(string email, string password)
    {
        _logger.LogInformation("User registration started");

        var result = await _service.Register(email, password);
        return JsonContent(new { state = result.IsOK, message = result.Message });
    }
}