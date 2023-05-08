using System.ComponentModel.DataAnnotations;

namespace Zahradneek.Api.Contracts.v1.Requests;

public record UpdateCoordinateRequest
{
    [Required] public double Latitude { get; set; }
    [Required] public double Longitude { get; set; }

    [Required] public int ParcelId { get; set; }
}