using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
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

    [HttpGet("{coordinateId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int coordinateId) =>
        Ok(await _coordinateService.GetByIdAsync(coordinateId));

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Create([FromBody] CreateCoordinateRequest request)
    {
        await _coordinateService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{coordinateId:int}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateById(
        [FromBody] UpdateCoordinateRequest request,
        [FromRoute] int coordinateId
    )
    {
        await _coordinateService.UpdateByIdAsync(
            coordinateId: coordinateId,
            request: request
        );
        return NoContent();
    }

    [HttpDelete("{coordinateId:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int coordinateId)
    {
        await _coordinateService.DeleteByIdAsync(coordinateId);
        return NoContent();
    }
}