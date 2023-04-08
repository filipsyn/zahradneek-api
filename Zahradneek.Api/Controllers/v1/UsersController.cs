using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Services.UserService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<UserInfoResponse>), statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(type: typeof(UserInfoResponse), statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        return Ok(await _userService.GetByIdAsync(userId));
    }

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        await _userService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{userId}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateById([FromBody] UpdateUserRequest request, [FromRoute] int userId)
    {
        await _userService.UpdateByIdAsync(request: request, userId: userId);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteById([FromRoute] int userId)
    {
        await _userService.DeleteByIdAsync(userId);
        return NoContent();
    }
}