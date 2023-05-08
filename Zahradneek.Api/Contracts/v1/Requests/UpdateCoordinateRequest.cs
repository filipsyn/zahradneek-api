namespace Zahradneek.Api.Contracts.v1.Requests;

public record UpdateCoordinateRequest
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}