using System.Text;
using DataManager.DataContract;
using DomainModel.Models.Model;
using Enum.Enums;
using Microsoft.EntityFrameworkCore;
using Models.DefaultModels;
using Models.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Service.Common.User;

/// <summary>
/// Сервис по работе с пользователями
/// </summary>
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    /// <param name="username">Никнейм</param>
    /// <param name="email">Почта</param>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    /// <exception cref="AuthenticationException"></exception>
    public async Task<ExecuteResult> Register(RegisterRequest r)
    {
        try
        {
            if (await _context.Users.AnyAsync(e => e.Email == r.Email || e.Username == r.Username))
            {
                throw new AuthenticationException
                (
                    new ExecuteResult
                    {
                        State = ExecuteState.Error,
                        Message = $"Почта или никнейм уже зарегистрированы в системе",
                        MessageCode = "409"
                    }
                );
            }

            var check = IsStrongPassword(r.Password);
            if (!check.IsOK)
                throw new AuthenticationException(check);

            var passwordHash = BCryptNet.HashPassword(r.Password);

            var reg = new DomainModel.Models.Entity.User
            {
                Username = r.Username,
                Email = r.Email,
                Password = passwordHash,
                Role = UserRole.User,
                Wins = 0,
                Losses = 0,
                Winrate = 0f,
                AvatarUrl = $"https://api.dicebear.com/10.x/lorelei/svg?seed=user-{r.Email}"
            };
            
            await _context.Users.AddAsync(reg);
            await _context.SaveChangesAsync();
            
            return new ExecuteResult
            {
                State = ExecuteState.OK,
                Message = $"Регистрация прошла успешно, можете авторизоваться",
                MessageCode = "200"
            };
        }
        
        catch (AuthenticationException e)
        {
            return e.Result;
        }
    } 
    
    private static ExecuteResult IsStrongPassword(string password)
    {
        Dictionary<string, bool> check = new Dictionary<string, bool>
        {
            { "Пароль не может быть меньше 8 символов", password.Length >= 8 },
            { "В пароле должна быть хотя бы одна заглавная буква", password.Any(char.IsUpper) },
            { "В пароле должна быть хотя бы одна маленькая буква", password.Any(char.IsLower) },
            { "В пароле должна быть хотя бы одна цифра", password.Any(char.IsDigit) }
        };

        if (check.ContainsValue(false))
        {
            StringBuilder error = new StringBuilder();

            foreach (var item in check)
            {
                if (!item.Value)
                {
                    error.AppendLine(item.Key);
                }
            }

            return new ExecuteResult
            {
                State = ExecuteState.Error,
                Message = error.ToString(),
                MessageCode = "409"
            };
        }

        return new ExecuteResult { State = ExecuteState.OK };
    }
}