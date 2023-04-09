using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Repositories.UserRepository;
using Zahradneek.Api.Services.UserService;

namespace Zahradneek.Api.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public AuthService(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task RegisterAsync(CreateUserRequest request)
    {
        var existingUser = _userRepository.GetByUsernameAsync(request.Username);
        if (existingUser is not null)
            throw new ConflictException($"Username '{request.Username}' is taken");

        await _userService.CreateAsync(request);
    }

    public async Task<string> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}