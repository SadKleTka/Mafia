namespace DomainModel.Models.Model;

/// <summary>
/// Модель для логина пользователя
/// </summary>
public record LoginRequest(
    string Login,
    string Password
);
