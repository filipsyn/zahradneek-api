using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.CoordinateRepository;

public interface ICoordinateRepository
{
    // Get all coordinates
    public Task<IEnumerable<Coordinate>> GetAllAsync();

    // Get all coordinates for parcel
    public Task<IEnumerable<Coordinate>> GetAllForParcelAsync(int parcelId);

    // Get coordinate by id
    public Task<Coordinate?> GetByIdAsync(int coordinateId);

    // Create New coordinate for parcel
    public Task CreateForParcelAsync(Coordinate coordinate);

    // Update coordinate
    public Task UpdateByIdAsync(int coordinateId, Coordinate updatedCoordinate);

    // Delete coordinate
    public Task DeleteByIdAsync(int coordinateId);
}