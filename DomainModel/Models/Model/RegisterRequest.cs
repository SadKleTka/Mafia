namespace DomainModel.Models.Model;

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public record RegisterRequest(
    string Username,
    string Email,
    string Password
);
