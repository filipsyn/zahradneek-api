using Zahradneek.Api.Models;

namespace Zahradneek.Api.Contracts.v1;

public record CreateParcelRequest
{
    public string? Name { get; init; }
    public List<Coordinate>? Coordinates { get; init; }
};