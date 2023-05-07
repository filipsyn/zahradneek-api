using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Data;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.CoordinateRepository;

public class CoordinateRepository : ICoordinateRepository
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public CoordinateRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Coordinate>> GetAllAsync() =>
        await _db.Coordinates.ToListAsync();

    public async Task<IEnumerable<Coordinate>> GetAllForParcelAsync(int parcelId) =>
        await _db.Coordinates
            .Where(coord => coord.ParcelId == parcelId)
            .ToListAsync();

    public async Task<Coordinate?> GetByIdAsync(int coordinateId) =>
        await _db.Coordinates
            .Where(coord => coord.Id == coordinateId)
            .FirstOrDefaultAsync();

    public async Task CreateAsync(Coordinate coordinate)
    {
        _db.Coordinates.Add(coordinate);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateByIdAsync(int coordinateId, Coordinate updatedCoordinate)
    {
        var coordinate = await _db.Coordinates.FirstOrDefaultAsync(c => c.Id == coordinateId);
        if (coordinate is null)
            throw new NotFoundException("Coordinates were not found");

        _mapper.Map(updatedCoordinate, coordinate);
        _db.Coordinates.Update(coordinate);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int coordinateId)
    {
        var foundCoordinates = await this.GetByIdAsync(coordinateId);
        if (foundCoordinates is null)
            throw new NotFoundException("Coordinates were not found");

        _db.Coordinates.Remove(foundCoordinates);
        await _db.SaveChangesAsync();
    }
}