using System.Diagnostics;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
using Zahradneek.Api.Repositories.ParcelRepository;
using Zahradneek.Api.Repositories.WaterLogRepository;

namespace Zahradneek.Api.Services.WaterLogService;

public class WaterLogService : IWaterLogService
{
    private readonly IWaterLogRepository _waterLogRepository;
    private readonly IMapper _mapper;
    private readonly IParcelRepository _parcelRepository;

    public WaterLogService(IWaterLogRepository waterLogRepository, IMapper mapper, IParcelRepository parcelRepository)
    {
        _waterLogRepository = waterLogRepository;
        _mapper = mapper;
        _parcelRepository = parcelRepository;
    }

    public async Task<WaterLogInfoResponse> GetByIdAsync(int waterLogId)
    {
        var waterLog = await _waterLogRepository.GetByIdAsync(waterLogId);

        if (waterLog is null)
            throw new NotFoundException("Water Log was not found");

        return _mapper.Map<WaterLogInfoResponse>(waterLog);
    }

    public async Task<IEnumerable<WaterLogInfoResponse>> GetAllAsync()
    {
        var waterLogs = await _waterLogRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<WaterLogInfoResponse>>(waterLogs);
    }

    public async Task<IEnumerable<WaterLogInfoResponse>> GetAllByParcelId(int parcelId)
    {
        var foundParcel = await _parcelRepository.GetByIdAsync(parcelId);
        if (foundParcel is null)
            throw new NotFoundException("Parcel was not found");

        var waterLogs = await _waterLogRepository.GetAllForParcelIdAsync(parcelId);

        return _mapper.Map<IEnumerable<WaterLogInfoResponse>>(waterLogs);
    }

    public async Task CreateAsync(CreateWaterLogRequest request)
    {
        var waterLog = _mapper.Map<WaterLog>(request);

        try
        {
            await _waterLogRepository.CreateAsync(waterLog);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task UpdateByIdAsync(UpdateWaterLogRequest request, int waterLogId)
    {
        var waterLog = await _waterLogRepository.GetByIdAsync(waterLogId);

        if (waterLog is null)
            throw new NotFoundException("Water Log was not found");

        var updatedWaterLog = _mapper.Map<WaterLog>(request);

        try
        {
            await _waterLogRepository.UpdateAsync(
                updatedWaterLog: updatedWaterLog,
                waterLogId: waterLogId
            );
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task DeleteByIdAsync(int waterLogId)
    {
        var waterLog = await _waterLogRepository.GetByIdAsync(waterLogId);
        if (waterLog is null)
            throw new NotFoundException("Water Log was not found");

        try
        {
            await _waterLogRepository.DeleteByIdAsync(waterLogId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }
}