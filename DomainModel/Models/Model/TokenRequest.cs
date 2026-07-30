namespace DomainModel.Models.Model;

/// <summary>
/// Модель для создания токена
/// </summary>
public class TokenRequest
{
    public string Id {get; set;}
    public string Email { get; set; }
    public string Role { get; set; }
}