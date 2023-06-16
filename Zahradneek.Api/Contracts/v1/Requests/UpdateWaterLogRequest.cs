using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1.Requests;

public record UpdateWaterLogRequest
{
    [Required] public float Amount { get; init; }
    [Required] public int ParcelId { get; init; }
};