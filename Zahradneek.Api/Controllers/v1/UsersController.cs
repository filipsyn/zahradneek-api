using Microsoft.AspNetCore.Mvc;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("/users")]
public class UsersController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetById(Guid userId)
    {
        return Ok();
            
    }
}