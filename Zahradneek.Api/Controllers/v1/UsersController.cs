using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Services.UserService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(int userId)
    {
        return Ok(await _userService.GetByIdAsync(userId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        await _userService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateById(UpdateUserRequest request, int userId)
    {
        await _userService.UpdateByIdAsync(request: request, userId: userId);
        return NoContent();
    }
}