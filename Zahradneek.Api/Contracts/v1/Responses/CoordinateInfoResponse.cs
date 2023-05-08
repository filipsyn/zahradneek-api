namespace Zahradneek.Api.Contracts.v1.Responses;

public record CoordinateInfoResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public int ParcelId { get; set; }
}