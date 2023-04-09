namespace Zahradneek.Api.Contracts.v1;

public record LoginRequest
{
    public string Username { get; init; }
    public string Password { get; init; }
}