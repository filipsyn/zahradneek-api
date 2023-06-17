using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1.Requests;

public record CreateParcelRequest
{
    public string? Name { get; init; }
    [Required] public int OwnerId { get; set; }
};