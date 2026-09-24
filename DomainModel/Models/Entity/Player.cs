using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enum.Enums;

namespace DomainModel.Models.Entity;

/// <summary>
/// Энтити игрока
/// </summary>
public class Player
{
    public Player(string nickname, Guid userId, string avatarUrl, float winrate, GameRole role)
    {
        UserId = userId;
        Nickname = nickname;
        AvatarUrl = avatarUrl;
        Winrate = winrate;
        Role = role;
    }
    
    [Key]
    public string Nickname { get; set; }
    
    public string AvatarUrl { get; set; }
    
    [Display(Name = "Процент побед")]
    public float Winrate { get; set; }
    
    [Required]
    public GameRole Role { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
}