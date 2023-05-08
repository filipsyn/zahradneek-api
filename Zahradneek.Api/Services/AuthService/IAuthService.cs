using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;

namespace Zahradneek.Api.Services.AuthService;

public interface IAuthService
{
    public Task RegisterAsync(CreateUserRequest request);

    public Task<LoginResponse> LoginAsync(LoginRequest request);
}