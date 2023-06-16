using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1.Requests;

public record CreateWaterLogRequest
{
    [Required] public float Amount { get; init; }
    [Required] public int ParcelId { get; init; }
};