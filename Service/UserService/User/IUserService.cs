using Models.DefaultModels;

namespace Service.UserService.User;

public interface IUserService
{
    Task<ExecuteResult> Register(string email, string password);
}