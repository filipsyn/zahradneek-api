using Zahradneek.Api.Contracts.v1;

namespace Zahradneek.Api.Services.CoordinateService;

public interface ICoordinateService
{
    // Get all
    public Task<IEnumerable<CoordinateInfoResponse>> GetAllAsync();

    // Get all for parcel
    public Task<IEnumerable<CoordinateInfoResponse>> GetAllForParcel(int parcelId);

    // Get by id
    public Task<CoordinateInfoResponse> GetByIdAsync(int coordinateId);

    // Create async
    public Task CreateAsync(CreateCoordinateRequest request);

    // Update by id
    public Task UpdateByIdAsync(int coordinateId, UpdateCoordinateRequest request);

    // Delete by id
    public Task DeleteByIdAsync(int coordinateId);
}