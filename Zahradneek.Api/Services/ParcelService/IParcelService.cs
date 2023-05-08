using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;

namespace Zahradneek.Api.Services.ParcelService;

public interface IParcelService
{
    public Task<ParcelInfoResponse> GetByIdAsync(int parcelId);

    public Task<IEnumerable<ParcelInfoResponse>> GetAllAsync();

    public Task<IEnumerable<ParcelInfoResponse>> GetAllByOwnerIdAsync(int ownerId);

    public Task CreateAsync(CreateParcelRequest request);

    public Task UpdateByIdAsync(UpdateParcelRequest request, int parcelId);

    public Task DeleteByIdAsync(int parcelId);
}