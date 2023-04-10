namespace Zahradneek.Api.Models;

public class Parcel : BaseEntity
{
    public string? Name { get; set; }
    
    // Relationships
    
    // Relationship with User
    public int OwnerId { get; set; }
    public User Owner { get; set; } = new User();
    
    // Relationship with Coordinates
    public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
}