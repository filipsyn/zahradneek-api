using Newtonsoft.Json;

namespace Zahradneek.Api.Models;

public class WaterLog : BaseEntity
{
    public float Amount { get; set; }

    // Relationship with Parcel
    public int ParcelId { get; set; }
    [JsonIgnore] public Parcel Parcel { get; set; }
}