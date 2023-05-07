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