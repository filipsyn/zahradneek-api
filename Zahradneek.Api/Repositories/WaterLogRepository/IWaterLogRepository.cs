using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.WaterLogRepository;

public interface IWaterLogRepository
{
    public Task<WaterLog?> GetByIdAsync(int waterLogId);

    public Task<IEnumerable<WaterLog>> GetAllAsync();

    public Task<IEnumerable<WaterLog>> GetAllForParcelIdAsync(int parcelId);

    public Task CreateAsync(WaterLog waterLog);

    public Task UpdateAsync(WaterLog updatedWaterLog, int waterLogId);

    public Task DeleteByIdAsync(int waterLogId);
}