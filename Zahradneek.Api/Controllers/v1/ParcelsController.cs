using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Services.ParcelService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("/v1/parcels")]
[Produces("application/json")]
public class ParcelsController : ControllerBase
{
    private readonly IParcelService _parcelService;

    public ParcelsController(IParcelService parcelService)
    {
        _parcelService = parcelService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<ParcelInfoResponse>), statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll() =>
        Ok(await _parcelService.GetAllAsync());

    [HttpGet("{parcelId:int}")]
    [ProducesResponseType(type: typeof(ParcelInfoResponse), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int parcelId) =>
        Ok(await _parcelService.GetByIdAsync(parcelId));

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Create([FromBody] CreateParcelRequest request)
    {
        await _parcelService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{parcelId:int}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateById([FromBody] UpdateParcelRequest request, [FromRoute] int parcelId)
    {
        await _parcelService.UpdateByIdAsync(request: request, parcelId: parcelId);
        return NoContent();
    }

    [HttpDelete("{parcelId:int}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteById([FromRoute] int parcelId)
    {
        await _parcelService.DeleteByIdAsync(parcelId);
        return NoContent();
    }
}