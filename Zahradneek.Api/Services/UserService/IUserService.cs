using Zahradneek.Api.Contracts.v1;

namespace Zahradneek.Api.Services.UserService;

public interface IUserService
{
    public Task<UserInfoResponse> GetByIdAsync(Guid userId);
    public Task<IEnumerable<UserInfoResponse>> GetAllAsync();
    public Task<bool> CreateAsync(CreateUserRequest request);
    public Task<bool> UpdateByIdAsync(UpdateUserRequest request, Guid userId);
    public Task<bool> DeleteByIdAsync(Guid userId);
}