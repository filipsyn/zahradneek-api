using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
using Zahradneek.Api.Repositories.CoordinateRepository;

namespace Zahradneek.Api.Services.CoordinateService;

public class CoordinateService : ICoordinateService
{
    private readonly ICoordinateRepository _coordinateRepository;
    private readonly IMapper _mapper;

    public CoordinateService(ICoordinateRepository coordinateRepository, IMapper mapper)
    {
        _coordinateRepository = coordinateRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CoordinateInfoResponse>> GetAllAsync()
    {
        var coordinates = await _coordinateRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CoordinateInfoResponse>>(coordinates);
    }

    public async Task<IEnumerable<CoordinateInfoResponse>> GetAllForParcel(int parcelId)
    {
        var coordinates = await _coordinateRepository.GetAllForParcelAsync(parcelId);
        return _mapper.Map<IEnumerable<CoordinateInfoResponse>>(coordinates);
    }

    public async Task<CoordinateInfoResponse> GetByIdAsync(int coordinateId)
    {
        var coordinate = await _coordinateRepository.GetByIdAsync(coordinateId);
        if (coordinate is null)
            throw new NotFoundException("Coordinates were not found");

        return _mapper.Map<CoordinateInfoResponse>(coordinate);
    }

    public async Task CreateAsync(CreateCoordinateRequest request)
    {
        var coordinate = _mapper.Map<Coordinate>(request);

        try
        {
            await _coordinateRepository.CreateAsync(coordinate);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task UpdateByIdAsync(int coordinateId, UpdateCoordinateRequest request)
    {
        var coordinate = await _coordinateRepository.GetByIdAsync(coordinateId);

        if (coordinate is null)
            throw new NotFoundException("Coordinates were not found");

        var updatedCoordinate = _mapper.Map<Coordinate>(request);

        try
        {
            await _coordinateRepository.UpdateByIdAsync(
                coordinateId: coordinateId,
                updatedCoordinate: updatedCoordinate
            );
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task DeleteByIdAsync(int coordinateId)
    {
        var coordinate = await _coordinateRepository.GetByIdAsync(coordinateId);
        if (coordinate is null)
            throw new NotFoundException("Coordinates were not found");

        try
        {
            await _coordinateRepository.DeleteByIdAsync(coordinateId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }
}