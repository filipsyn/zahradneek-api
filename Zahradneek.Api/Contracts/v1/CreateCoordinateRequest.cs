namespace Zahradneek.Api.Contracts.v1;

public record CreateCoordinateRequest
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public int ParcelId { get; set; }
}