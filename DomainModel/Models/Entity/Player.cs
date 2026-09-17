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
    
    public Guid PlayerId { get; set; }
    
    public GameRole Role { get; set; }
}