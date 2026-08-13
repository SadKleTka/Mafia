using Microsoft.AspNetCore.Mvc;
using DomainModel.Models.Model;
using Service.Common.Auth;

namespace Mafia.Web.MVC.Auth;

/// <summary>
/// Контроллер для работы с пользователем
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : MafiaOnlineController
{
    private readonly IAuthService _service;
    
    public AuthController(ILoggerFactory loggerFactory, IAuthService service) : base(loggerFactory)
    {
        _service = service;
    }

    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    /// <param name="request">Параметры для регистрации</param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")] 
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _service.Register(request);
        
        _logger.Log(result.Message, result.State);
        return JsonContent(new { state = result.IsOK, message = result.Message, serviceResponse = result.MessageCode });
    }

    /// <summary>
    /// Аутентификация
    /// </summary>
    /// <param name="request">Параметры для аутентификации</param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _service.Login(request);
        
        _logger.Log(result.Message, result.State);
        return JsonContent(new { state = result.IsOK, message = result.Message, serviceResponse = result.MessageCode });
    }
}