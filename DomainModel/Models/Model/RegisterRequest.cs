namespace DomainModel.Models.Model;

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}