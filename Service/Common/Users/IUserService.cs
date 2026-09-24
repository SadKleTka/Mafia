using DomainModel.Models.Entity;
using DomainModel.Models.Model.User;
using Models.DefaultModels.User;

namespace Service.Common.Users;

/// <summary>
/// Интерфейс для работы с пользователями 
/// </summary>
public interface IUserService
{
    Task<UserExecuteResult> GetAllUsers();
    Task<UserExecuteResult> SearchUsersByName(string name);
}