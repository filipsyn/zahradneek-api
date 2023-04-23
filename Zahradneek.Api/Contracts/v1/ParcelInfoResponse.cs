using Zahradneek.Api.Models;

namespace Zahradneek.Api.Contracts.v1;

public record ParcelInfoResponse
{
    public int Id { get; init; }
    public int OwnerId { get; init; }
    public List<Coordinate> Coordinates { get; init; }
};