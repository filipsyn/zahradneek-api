using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Repositories.CoordinateRepository;
using Zahradneek.Api.Services.CoordinateService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("v1/coordinates")]
[Produces("application/json")]
public class CoordinatesController : ControllerBase
{
    private readonly ICoordinateService _coordinateService;

    public CoordinatesController(ICoordinateService coordinateService)
    {
        _coordinateService = coordinateService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<CoordinateInfoResponse>), statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll() =>
        Ok(await _coordinateService.GetAllAsync());
}