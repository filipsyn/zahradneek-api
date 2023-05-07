using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.CoordinateRepository;

public class CoordinateRepository : ICoordinateRepository
{
    public async Task<IEnumerable<Coordinate>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Coordinate>> GetAllForParcelAsync(int parcelId)
    {
        throw new NotImplementedException();
    }

    public async Task<Coordinate> GetByIdAsync(int coordinateId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateForParcelAsync(int parcelId, Coordinate coordinate)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateByIdAsync(int coordinateId, Coordinate updatedCoordinate)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int coordinateId)
    {
        throw new NotImplementedException();
    }
}