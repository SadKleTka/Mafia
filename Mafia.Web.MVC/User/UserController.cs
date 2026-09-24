using Enum.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Users;

namespace Mafia.Web.MVC.UserController;

/// <summary>
/// Контроллер для получения пользователей
/// </summary>
[ApiController]
[Route("api/[controller]")] 
public class UserController : MafiaOnlineController
{
    private readonly IUserService _userService;

    public UserController(ILoggerFactory loggerFactory ,IUserService userService) :base(loggerFactory)
    {
        _userService = userService;
    }
    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <returns></returns>Список всех пользователей
    [HttpGet]
    [Route("getAllUsers")]
    public async Task<ActionResult> GetAllUsers()
    {
        var allUsers = await _userService.GetAllUsers();
        _logger.Log("Список пользователей получен", ExecuteState.OK);
        
        return JsonContent(new
        {
            state = true,
            message = allUsers.Message,
            users = allUsers.User
        });
    }
 
    /// <summary>
    /// Поиск пользоватлей по имени
    /// </summary>
    /// <param name="name"></param>Имя пользователя
    /// <returns></returns>Список пользователей с совпадающим именем
    [HttpGet]
    [Route("searchUsersByName")]
    public async Task<ActionResult> SearchUsersByName(string name)
    {
       var searchedUsers = await _userService.SearchUsersByName(name);
       _logger.Log("Список пользователей по имени получен", ExecuteState.OK);
        
       return JsonContent(new
       {
           state = true,
           message = searchedUsers.Message,
           users = searchedUsers.User
       });
    }
}