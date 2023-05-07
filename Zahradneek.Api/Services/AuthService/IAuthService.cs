using Zahradneek.Api.Contracts.v1;

namespace Zahradneek.Api.Services.AuthService;

public interface IAuthService
{
    public Task RegisterAsync(CreateUserRequest request);

    public Task<LoginResponse> LoginAsync(LoginRequest request);
}