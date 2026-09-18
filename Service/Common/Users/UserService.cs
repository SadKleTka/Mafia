using DataManager.DataContract;
using DomainModel.Models.Entity;
using DomainModel.Models.Model.User;
using Enum.Enums;
using Microsoft.EntityFrameworkCore;
using Models.DefaultModels.User;


namespace Service.Common.Users;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Поиск пользоватлей по имени
    /// </summary>
    /// <returns></returns>Список пользователей 
    public async Task<UserExecuteResult> GetAllUsers()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        var response = users.Select(u => new UsersResponse
        {
            UserId = u.UserId,
            Username = u.Username,
            Role = u.Role,
            Wins = u.Wins,
            Losses = u.Losses,
            Winrate = u.Winrate,
            AvatarUrl = u.AvatarUrl,
        });
        if(!users.Any())
        {
            return new UserExecuteResult
            {
                MessageCode = "200",
                Message = "Пользователи не найдены",
                State = ExecuteState.OK,
                User = response
            };
        }
        
        return new UserExecuteResult
        {
            MessageCode = "200",
            Message = "Список пользователей получен",
            State = ExecuteState.OK,
            User = response
        };

    }

    /// <summary>
    /// Поиск пользоватлей по имени
    /// </summary>
    /// <param name="name"></param>Имя пользователя
    /// <returns></returns>Список пользователей с совпадающим именем
    public async Task<UserExecuteResult> SearchUsersByName(string name)
    {
        var foundUsers = await _context.Users.AsNoTracking().Where(u => u.Username.ToLower().Contains(name.ToLower())).OrderBy(u => u.Username.Length).ToListAsync();
        var response = foundUsers.Select(u => new UsersResponse
        {
            UserId = u.UserId,
            Username = u.Username,
            Role = u.Role,
            Wins = u.Wins,
            Losses = u.Losses,
            Winrate = u.Winrate,
            AvatarUrl = u.AvatarUrl,
        });
            if(!foundUsers.Any())
            {
                return new UserExecuteResult
                {
                    MessageCode = "200",
                    Message = "Пользователи с таким именем не найдены",
                    State = ExecuteState.OK,
                    User = response
                };
            }
        
        return new UserExecuteResult
        {
            MessageCode = "200",
            Message = "Список пользователей по имени получен",
            State = ExecuteState.OK,
            User = response
        };
    }
}