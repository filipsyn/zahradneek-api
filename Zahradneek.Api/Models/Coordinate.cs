namespace Zahradneek.Api.Models;

public class Coordinate : BaseEntity
{
    public float Longitude { get; set; }
    public float Latitude { get; set; }

    // Relationship
    public int ParcelId { get; set; }
    public Parcel Parcel { get; set; } = new Parcel();
}