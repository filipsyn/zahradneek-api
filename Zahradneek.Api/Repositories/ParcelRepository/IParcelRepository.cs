using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.ParcelRepository;

public interface IParcelRepository
{
    public Task<IEnumerable<Parcel>> GetAllAsync();

    public Task<Parcel?> GetByIdAsync(int parcelId);

    public Task<IEnumerable<Parcel>> GetAllByOwnerIdAsync(int ownerId);

    public Task CreateAsync(Parcel parcel);

    public Task UpdateByIdAsync(Parcel updatedParcel, int parcelId);

    public Task DeleteByIdAsync(int parcelId);
}