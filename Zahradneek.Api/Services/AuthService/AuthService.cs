using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
using Zahradneek.Api.Repositories.UserRepository;
using Zahradneek.Api.Services.UserService;

namespace Zahradneek.Api.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IUserService userService, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _userService = userService;
        _configuration = configuration;
    }

    public async Task RegisterAsync(CreateUserRequest request)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
        if (existingUser is not null)
            throw new ConflictException($"Username '{request.Username}' is taken");

        await _userService.CreateAsync(request);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user is null)
            throw new IncorrectCredentialsException();

        if (!await VerifyPasswordAsync(request))
            throw new IncorrectCredentialsException();

        return new LoginResponse(GenerateJwtToken(user));
    }

    private async Task<bool> VerifyPasswordAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user is null)
            throw new IncorrectCredentialsException();

        return BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value!)
        );

        var credentials = new SigningCredentials(key: key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}