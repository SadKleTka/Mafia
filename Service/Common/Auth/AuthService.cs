using System.Text;
using DataManager.DataContract;
using DomainModel.Models.Model;
using Enum.Enums;
using Microsoft.EntityFrameworkCore;
using Models.DefaultModels;
using Models.Exceptions;
using Security.Authentication.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Service.Common.Auth;

/// <summary>
/// Сервис по работе с пользователями
/// </summary>
public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(AppDbContext context, IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    /// <summary>
    /// Выполняет вход пользователя на сайт
    /// </summary>
    /// <param name="request">Параметры для входа пользователя</param>
    /// <returns></returns>
    public async Task<ExecuteResult> Login(LoginRequest request)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(e =>
            e.Email == request.Login || e.Username == request.Login);

        if (user is null || !BCryptNet.Verify(request.Password, user.Password))
            return new ExecuteResult("Неправильный логин или пароль", ExecuteState.Error, "401");

        var token = _jwtTokenGenerator.GenerateToken(new TokenRequest
        {
            Email = user.Email,
            Id = user.UserId.ToString(),
            Role = user.Role.ToString()
        });
        if (string.IsNullOrWhiteSpace(token))
            return new ExecuteResult("Не найдены параметры для создания токена", ExecuteState.Error, "500");

        return new ExecuteResult
        {
            State = ExecuteState.OK,
            Message = token,
            MessageCode = "200"
        };
    }

    /// <summary>
    /// Регистрация нового пользователя
    /// </summary>
    /// <param name="r">Параметры для регистрации</param>
    /// <returns></returns>
    /// <exception cref="AuthenticationException"></exception>
    public async Task<ExecuteResult> Register(RegisterRequest r)
    {
        if (await _context.Users.AnyAsync(e => e.Email == r.Email || e.Username == r.Username))
            return new ExecuteResult("Почта или никнейм уже зарегистрированы в системе", ExecuteState.Error, "409");

        var check = IsStrongPassword(r.Password);
        if (!check.IsOK)
            return check;

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
            
        _context.Users.Add(reg);
        await _context.SaveChangesAsync();
            
        return new ExecuteResult
        {
            State = ExecuteState.OK,
            Message = $"Регистрация прошла успешно, можете авторизоваться",
            MessageCode = "200"
        };
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