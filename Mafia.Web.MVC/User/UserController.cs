using Microsoft.AspNetCore.Mvc;
using DomainModel.Models.Model;
using Service.Common.User;

namespace Mafia.Web.MVC.User;

/// <summary>
/// Контроллер для работы с пользователем
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : MafiaOnlineController
{
    private readonly IUserService _service;
    private readonly ILogger<UserController> _logger;
    
    public UserController(IUserService service, ILogger<UserController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Регистация нового пользователя
    /// </summary>
    /// <param name="username">Никнейм</param>
    /// <param name="email">Почта</param>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")] 
    public async Task<ActionResult> Register
        (
            [FromBody] RegisterRequest request
        )
    {
        var result = await _service.Register(request);
        
        _logger.LogInformation(result.Message);
        return JsonContent(new { state = result.IsOK, message = result.Message });
    }
}