using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1.Requests;

public record CreateNewsRequest
{
    [Required] public string Title { get; set; } = string.Empty;
    [Required] public string Content { get; set; } = string.Empty;
    [Required] public int AuthorId { get; set; }
};