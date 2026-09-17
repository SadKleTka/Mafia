using DomainModel.Models.Entity;
using DomainModel.Models.Model.User;
using Models.DefaultModels.User;

namespace Service.Common.Users;

public interface IUserService
{
    Task<UserExecuteResult> GetAllUsers();
    Task<UserExecuteResult> SearchUsersByName(string name);
}