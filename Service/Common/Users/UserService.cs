using DataManager.DataContract;
using DomainModel.Models.Entity;
using Microsoft.EntityFrameworkCore;


namespace Service.Common.Users;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
       
        return users;
    }
}