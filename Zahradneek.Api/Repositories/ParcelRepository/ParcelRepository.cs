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

    public async Task<IEnumerable<Parcel>> GetAllAsync()
    {
        return await _db.Parcels.Include(x => x.Coordinates).ToListAsync();
    }

    public async Task<Parcel?> GetByIdAsync(int parcelId)
    {
        return await _db.Parcels.Where(x => x.Id == parcelId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Parcel>> GetAllByOwnerIdAsync(int ownerId)
    {
        return await _db.Parcels.Where(x => x.OwnerId == ownerId).ToListAsync();
    }

    public async Task CreateAsync(Parcel parcel)
    {
        _db.Parcels.Add(parcel);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateByIdAsync(Parcel updatedParcel, int parcelId)
    {
        var parcel = await _db.Parcels.FirstOrDefaultAsync(x => x.Id == parcelId);
        if (parcel is null)
            throw new NotFoundException("Parcel was not found");

        //TODO: Finish Updating
        _mapper.Map(updatedParcel, parcel);
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