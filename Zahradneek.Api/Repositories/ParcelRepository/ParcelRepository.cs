using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Data;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.ParcelRepository;

public class ParcelRepository : IParcelRepository
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public ParcelRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Parcel>> GetAllAsync() =>
        await _db.Parcels
            .Include(x => x.Owner)
            .Include(x => x.WaterLogs)
            .Include(x => x.Coordinates)
            .ToListAsync();

    public async Task<Parcel?> GetByIdAsync(int parcelId) =>
        await _db.Parcels
            .Where(x => x.Id == parcelId)
            .Include(x => x.Owner)
            .Include(x => x.WaterLogs)
            .Include(x => x.Coordinates)
            .FirstOrDefaultAsync();

    public async Task<bool> IsOwner(int userId, int parcelId)
    {
        var parcel = await this.GetByIdAsync(parcelId);
        if (parcel is null)
            throw new NotFoundException("Parcel was not found");

        return parcel.OwnerId == userId;
    }

    public async Task<IEnumerable<Parcel>> GetAllByOwnerIdAsync(int ownerId) =>
        await _db.Parcels
            .Include(x => x.Owner)
            .Include(x => x.WaterLogs)
            .Include(x => x.Coordinates)
            .Where(x => x.OwnerId == ownerId)
            .ToListAsync();

    public async Task<int> CreateAsync(Parcel parcel)
    {
        _db.Parcels.Add(parcel);
        await _db.SaveChangesAsync();

        return parcel.Id;
    }

    public async Task UpdateByIdAsync(Parcel updatedParcel, int parcelId)
    {
        var parcel = await _db.Parcels.FirstOrDefaultAsync(x => x.Id == parcelId);
        if (parcel is null)
            throw new NotFoundException("Parcel was not found");

        _mapper.Map(updatedParcel, parcel);
        parcel.OwnerId = updatedParcel.OwnerId;

        _db.Parcels.Update(parcel);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int parcelId)
    {
        var foundParcel = await this.GetByIdAsync(parcelId);
        if (foundParcel is null)
            throw new NotFoundException("Parcel was not found");
        _db.Parcels.Remove(foundParcel);
        await _db.SaveChangesAsync();
    }
}