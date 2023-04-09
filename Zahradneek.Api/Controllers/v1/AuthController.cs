using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Services.AuthService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
    {
        await _authService.RegisterAsync(request);

        return NoContent();
    }

    [HttpPost("login")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent, type: typeof(LoginResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request) =>
        Ok(await _authService.LoginAsync(request));
}