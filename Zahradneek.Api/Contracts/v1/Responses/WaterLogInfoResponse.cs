namespace Zahradneek.Api.Contracts.v1.Responses;

public record WaterLogInfoResponse
{
    public int Id { get; init; }

    public float Amount { get; init; }
    public int ParcelId { get; init; }

    public DateTime CreatedAt { get; init; }
    public DateTime ModifiedAt { get; init; }
};