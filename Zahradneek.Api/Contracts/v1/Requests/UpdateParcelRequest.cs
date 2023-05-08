using Zahradneek.Api.Models;

namespace Zahradneek.Api.Contracts.v1.Requests;

public record UpdateParcelRequest
{
    public string? Name { get; init; }
    public List<UpdateCoordinateRequest>? Coordinates { get; init; }
};