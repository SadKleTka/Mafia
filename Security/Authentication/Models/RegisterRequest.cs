namespace Authentication.Models;

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public class RegisterRequest
{
    public string Email { get; set; }
    public string password { get; set; }
}