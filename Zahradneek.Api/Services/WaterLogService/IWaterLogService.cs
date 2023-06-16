using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;

namespace Zahradneek.Api.Services.WaterLogService;

public interface IWaterLogService
{
    public Task<WaterLogInfoResponse> GetByIdAsync(int waterLogId);

    public Task<IEnumerable<WaterLogInfoResponse>> GetAllAsync();

    public Task<IEnumerable<WaterLogInfoResponse>> GetAllByParcelId(int parcelId);

    public Task CreateAsync(CreateWaterLogRequest request);

    public Task UpdateByIdAsync(UpdateWaterLogRequest request, int waterLogId);

    public Task DeleteByIdAsync(int waterLogId);
}