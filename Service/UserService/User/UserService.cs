using Enum.Enums;
using Models.DefaultModels;

namespace Service.UserService.User;

/// <summary>
/// Сервис по работе с пользователями
/// </summary>
public class UserService : IUserService
{
    public async Task<ExecuteResult> Register(string email, string password)
    {
        return new ExecuteResult
        {
            State = ExecuteState.OK,
            Message = $"User {email} registered successfully",
            MessageCode = "200"
        };
    }
}