using DomainModel.Models.Entity;

namespace Service.Common.Users;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
}