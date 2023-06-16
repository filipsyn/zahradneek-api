using Newtonsoft.Json;

namespace Zahradneek.Api.Models;

public class Parcel : BaseEntity
{
    public string? Name { get; set; }

    // Relationship with User
    public int OwnerId { get; set; }
    [JsonIgnore] public User Owner { get; set; }

    // Relationship with Coordinates
    public List<Coordinate> Coordinates { get; set; }

    // Relationship with WaterLog
    public List<WaterLog> WaterLogs { get; set; }
}