namespace Zahradneek.Api.Contracts.v1.Responses;

public record ParcelInfoResponse
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public int OwnerId { get; init; }
    public List<CoordinateInfoResponse> Coordinates { get; init; }
    public List<WaterLogInfoResponse> WaterLogs { get; init; }
};