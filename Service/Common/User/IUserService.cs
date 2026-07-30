using DomainModel.Models.Model;
using Models.DefaultModels;

namespace Service.Common.User;

/// <summary>
/// Интерфейс по работе с пользователями
/// </summary>
public interface IUserService
{
    Task<ExecuteResult> Register(RegisterRequest request);
}