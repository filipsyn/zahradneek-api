using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.ParcelRepository;

public interface IParcelRepository
{
    public Task<IEnumerable<Parcel>> GetAllAsync();

    public Task<Parcel?> GetById(int parcelId);

    public Task<IEnumerable<Parcel>> GetAllByOwnerId(int ownerId);

    public Task CreateAsync(Parcel parcel);

    public Task UpdateByIdAsync(Parcel parcel, int parcelId);

    public Task DeleteByIdAsync(int parcelId);
}