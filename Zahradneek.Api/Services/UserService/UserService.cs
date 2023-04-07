using Zahradneek.Api.Contracts.v1;

namespace Zahradneek.Api.Services.UserService;

public class UserService : IUserService
{
    public async Task<UserInfoResponse> GetByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserInfoResponse>> GetAllAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateByIdAsync(UpdateUserRequest request, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}