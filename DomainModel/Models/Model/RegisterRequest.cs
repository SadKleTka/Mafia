using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models.Model;

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public record RegisterRequest(
    string Username,
    [EmailAddress]
    string Email,
    string Password
);
