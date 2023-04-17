using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.ParcelRepository;

public class ParcelRepository : IParcelRepository
{
    public async Task<IEnumerable<Parcel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Parcel?> GetById(int parcelId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Parcel>> GetAllByOwnerId(int ownerId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Parcel parcel)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateByIdAsync(Parcel parcel, int parcelId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int parcelId)
    {
        throw new NotImplementedException();
    }
}