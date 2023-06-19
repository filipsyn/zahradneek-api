namespace Zahradneek.Api.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    //TODO: Change default role to "User"
    public string Role { get; set; } = "Admin";

    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }

    // Relationships
    public List<Parcel> Parcels { get; set; }
}