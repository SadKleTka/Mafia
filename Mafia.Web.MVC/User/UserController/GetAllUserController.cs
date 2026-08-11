using DomainModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Common.UserService;
namespace Mafia.Web.MVC.UserController;

[ApiController]
[Route("[controller]")]

public class GetAllUserController
{
    private readonly IUserService _userService;

    public GetAllUserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [Route("getUsers")]
    public async Task<IEnumerable<User>> getAllUsers()
    {
        var allUsers = await _userService.GetAllUsers();
        return (allUsers);
    }
}