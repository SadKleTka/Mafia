using DomainModel.Models.Entity;
using Enum.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Users;
namespace Mafia.Web.MVC.UserController;

[ApiController]
[Route("[controller]")]

public class UserController : MafiaOnlineController
{
    private readonly IUserService _userService;

    public UserController(ILoggerFactory loggerFactory ,IUserService userService) :base(loggerFactory)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [Route("getUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var allUsers = await _userService.GetAllUsers();
        _logger.Log("Список пользователей успешно получен", ExecuteState.OK);
        return Ok(allUsers);
    }
}