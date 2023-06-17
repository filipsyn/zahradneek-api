namespace Zahradneek.Api.Contracts.v1.Responses;

public record NewsInfoResponse
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}