using AutoMapper;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Repositories.UserRepository;

namespace Zahradneek.Api.Services.UserService;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

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