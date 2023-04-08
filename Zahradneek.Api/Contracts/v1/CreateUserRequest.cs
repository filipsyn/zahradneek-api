using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1;

public record CreateUserRequest
{
    [Required] [StringLength(50)] public string FirstName { get; init; } = string.Empty;

    [Required] [StringLength(50)] public string LastName { get; init; } = string.Empty;

    [Required] [StringLength(50)] public string Username { get; init; } = string.Empty;
    
    [Required] public string Password { get; init; } = string.Empty;

    [Required] [EmailAddress] public string Email { get; init; } = string.Empty;

    [Required] [Phone] public string PhoneNumber { get; init; } = string.Empty;

    [Required] public DateTime DateOfBirth { get; init; }
}