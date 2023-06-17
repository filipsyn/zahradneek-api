using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Data;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.WaterLogRepository;

public class WaterLogRepository : IWaterLogRepository
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public WaterLogRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<WaterLog?> GetByIdAsync(int waterLogId)
        => await _db.WaterLogs.FirstOrDefaultAsync(log => log.Id == waterLogId);

    public async Task<IEnumerable<WaterLog>> GetAllAsync()
        => await _db.WaterLogs.ToListAsync();

    public async Task<IEnumerable<WaterLog>> GetAllForParcelIdAsync(int parcelId)
        => await _db.WaterLogs
            .Include(x => x.Parcel)
            .Where(x => x.ParcelId == parcelId)
            .ToListAsync();

    public async Task CreateAsync(WaterLog waterLog)
    {
        _db.WaterLogs.Add(waterLog);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(WaterLog updatedWaterLog, int waterLogId)
    {
        var waterLog = await GetByIdAsync(waterLogId);
        if (waterLog is null)
            throw new NotFoundException("Water Log was not found");

        _mapper.Map(updatedWaterLog, waterLog);
        waterLog.ParcelId = updatedWaterLog.ParcelId;

        _db.WaterLogs.Update(waterLog);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int waterLogId)
    {
        var foundWaterLog = await GetByIdAsync(waterLogId);

        if (foundWaterLog is null)
            throw new NotFoundException("Water Log was not found");

        _db.WaterLogs.Remove(foundWaterLog);
        await _db.SaveChangesAsync();
    }
}