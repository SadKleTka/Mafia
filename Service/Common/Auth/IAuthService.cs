using DomainModel.Models.Model;
using Models.DefaultModels;

namespace Service.Common.Auth;

/// <summary>
/// Интерфейс по работе с пользователями
/// </summary>
public interface IAuthService
{
    Task<ExecuteResult> Register(RegisterRequest request);
    
    Task<ExecuteResult> Login(LoginRequest request);
}