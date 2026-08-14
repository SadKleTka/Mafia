using Enum.Enums;


namespace DomainModel.Models.Model.User;


public class UsersResponse
{
    public Guid UserId { get; set; }
    
    public string Username { get; set; }
    
    public UserRole Role { get; set; }
   
    public int Wins { get; set; }
    
    public int Losses { get; set; }
    
    public float Winrate { get; set; }
    
    public string AvatarUrl { get; set; }

}