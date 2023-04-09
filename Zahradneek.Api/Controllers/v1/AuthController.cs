using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Services.AuthService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
}