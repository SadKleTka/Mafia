using DataManager.DataContract;
using Enum.Enums;
using Models.DefaultModels;
using Models.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Service.UserService.User;

/// <summary>
/// Сервис по работе с пользователями
/// </summary>
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ExecuteResult> Register(string email, string password)
    {
        try
        {
            
        }
        catch (AuthenticationException e)
        {
            return e.Result;
        }

        return new ExecuteResult
        {
            State = ExecuteState.OK,
            Message = $"User {email} registered successfully",
            MessageCode = "200"
        };
    }
}