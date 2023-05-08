namespace Zahradneek.Api.Contracts.v1.Responses;

public record CoordinateInfoResponse
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public int ParcelId { get; set; }
}