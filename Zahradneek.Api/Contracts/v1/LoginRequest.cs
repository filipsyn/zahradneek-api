using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1;

public record LoginRequest
{
    [Required] public string Username { get; init; } = string.Empty;
    [Required] public string Password { get; init; } = string.Empty;
}