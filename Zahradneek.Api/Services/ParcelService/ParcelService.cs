using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
using Zahradneek.Api.Repositories.ParcelRepository;

namespace Zahradneek.Api.Services.ParcelService;

public class ParcelService : IParcelService
{
    private readonly IParcelRepository _parcelRepository;
    private readonly IMapper _mapper;

    public ParcelService(IParcelRepository parcelRepository, IMapper mapper)
    {
        _parcelRepository = parcelRepository;
        _mapper = mapper;
    }

    public async Task<ParcelInfoResponse> GetByIdAsync(int parcelId)
    {
        var parcel = await _parcelRepository.GetByIdAsync(parcelId);
        if (parcel is null)
            throw new NotFoundException("Parcel was not found");

        return _mapper.Map<ParcelInfoResponse>(parcel);
    }

    public async Task<IEnumerable<ParcelInfoResponse>> GetAllAsync()
    {
        var parcels = await _parcelRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<ParcelInfoResponse>>(parcels);
    }

    public async Task<IEnumerable<ParcelInfoResponse>> GetAllByOwnerIdAsync(int ownerId)
    {
        var parcels = await _parcelRepository.GetAllByOwnerIdAsync(ownerId);

        return _mapper.Map<IEnumerable<ParcelInfoResponse>>(parcels);
    }

    public async Task<CreateParcelResponse> CreateAsync(CreateParcelRequest request)
    {
        var parcel = _mapper.Map<Parcel>(request);

        try
        {
            int id = await _parcelRepository.CreateAsync(parcel);
            return new CreateParcelResponse { Id = id, };
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task UpdateByIdAsync(UpdateParcelRequest request, int parcelId)
    {
        var parcel = await _parcelRepository.GetByIdAsync(parcelId);

        if (parcel is null)
            throw new NotFoundException("Parcel was not found");

        var updatedParcel = _mapper.Map<Parcel>(request);

        try
        {
            await _parcelRepository.UpdateByIdAsync(updatedParcel: updatedParcel, parcelId: parcelId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task DeleteByIdAsync(int parcelId)
    {
        var parcel = await _parcelRepository.GetByIdAsync(parcelId);
        if (parcel is null)
            throw new NotFoundException("Parcel was not found");

        try
        {
            await _parcelRepository.DeleteByIdAsync(parcelId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }
}