namespace Authentication.Models;

/// <summary>
/// Модель для логина пользователя
/// </summary>
public class LoginRequest
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
    
    public LoginRequest(string login, string password)
    {
        UserNameOrEmail = login;
        Password = password;
    }
}