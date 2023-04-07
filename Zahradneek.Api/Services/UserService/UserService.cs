using AutoMapper;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
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
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException("User was not found");

        return _mapper.Map<UserInfoResponse>(user);
    }

    public async Task<IEnumerable<UserInfoResponse>> GetAllAsync(Guid userId)
    {
        var users = await _userRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UserInfoResponse>>(users);
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