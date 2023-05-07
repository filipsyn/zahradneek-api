using Newtonsoft.Json;

namespace Zahradneek.Api.Models;

public class Coordinate : BaseEntity
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    // Relationship
    public int ParcelId { get; set; }
    [JsonIgnore]
    public Parcel Parcel { get; set; }
}