using DomainModel.Models.Model.User;
using Enum.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Users;
using DomainModel.Models.Model.User;

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
    public async Task<ActionResult> GetAllUsers()
    {
        var allUsers = await _userService.GetAllUsers();
       
        
        if (!allUsers.Any())
        {
            _logger.Log("Пользователи не найдены", ExecuteState.OK);
           
            return JsonContent(new
            {
                state = true,
                message = "Пользователи отсутствуют",
            });
        }
       
        var response = allUsers.Select(u => new UsersResponse
        {
            UserId = u.UserId,
            Username = u.Username,
            Role = u.Role,
            Wins = u.Wins,
            Losses = u.Losses,
            Winrate = u.Winrate,
            AvatarUrl = u.AvatarUrl,
        });
        
        _logger.Log("Список пользователей получен", ExecuteState.OK);
        
        return JsonContent(new
        {
            state = true,
            message = "Список пользователей получен",
            users = response
        });
    }
}