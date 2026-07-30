using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enum.Enums;

namespace DomainModel.Models.Entity;

/// <summary>
/// Модель класса пользователя
/// </summary>
[Table("User", Schema = "dbo")]
public class User
{
    /// <summary>
    /// Номер пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Никнейм
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Электронная почта
    /// </summary>
    [Required]
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public string Password { get; set; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public UserRole Role { get; set; }
    
    /// <summary>
    /// Победы
    /// </summary>
    [Display(Name = "Победы")]
    public int Wins { get; set; }
    
    /// <summary>
    /// Поражения
    /// </summary>
    [Display(Name = "Поражения")]
    public int Losses { get; set; }
    
    /// <summary>
    /// Процент побед
    /// </summary>
    [Display(Name = "Процент побед")]
    public float Winrate { get; set; }
    
    /// <summary>
    /// Аватарка
    /// </summary>
    public string AvatarUrl { get; set; }
    
    /// <summary>
    /// Статус сети
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Строковое представление объекта
    /// </summary>
    public override string ToString()
    {
        return this.Username;
    }
}