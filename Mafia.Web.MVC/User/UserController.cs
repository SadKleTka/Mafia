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