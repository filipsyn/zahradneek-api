using Zahradneek.Api.Contracts.v1;

namespace Zahradneek.Api.Services.UserService;

public interface IUserService
{
    public Task<UserInfoResponse> GetByIdAsync(Guid userId);
    public Task<IEnumerable<UserInfoResponse>> GetAllAsync();
    public Task CreateAsync(CreateUserRequest request);
    public Task UpdateByIdAsync(UpdateUserRequest request, Guid userId);
    public Task DeleteByIdAsync(Guid userId);
}