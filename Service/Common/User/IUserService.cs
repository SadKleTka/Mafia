using DomainModel.Models.Entity;

namespace Service.Common.UserService;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
}