namespace Zahradneek.Api.Contracts.v1.Responses;

public record NewsInfoResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public UserBriefInfoResponse Author { get; init; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}