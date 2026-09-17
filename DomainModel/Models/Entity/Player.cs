using System.ComponentModel.DataAnnotations;
using Enum.Enums;

namespace DomainModel.Models.Entity;

/// <summary>
/// Энтити игрока
/// </summary>
public class Player
{
    [Key]
    public string Nickname { get; set; }
    
    public string AvatarUrl { get; set; }
    
    [Display(Name = "Процент побед")]
    public float Winrate { get; set; }
    
    public GameRole Role { get; set; }
}