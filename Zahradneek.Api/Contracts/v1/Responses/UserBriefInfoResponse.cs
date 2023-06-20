namespace Zahradneek.Api.Contracts.v1.Responses;

public record UserBriefInfoResponse
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
}