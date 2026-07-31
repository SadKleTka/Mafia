using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Models.Entity;

/// <summary>
/// Энтити модель лобби
/// </summary>
[Table("Lobby")]
public class Lobby
{ 
    /// <summary>
    /// Номер лобби
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid LobbyId { get; set; }
    
    /// <summary>
    /// Название лобби
    /// </summary>
    [Required]
    public string Name { get; set; }
}