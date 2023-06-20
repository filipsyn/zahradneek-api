using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Authorization;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Services.CoordinateService;
using Zahradneek.Api.Services.ParcelService;
using Zahradneek.Api.Services.WaterLogService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("/v1/parcels")]
[Produces("application/json")]
public class ParcelsController : ControllerBase
{
    private readonly IParcelService _parcelService;
    private readonly ICoordinateService _coordinateService;
    private readonly IWaterLogService _waterLogService;

    public ParcelsController(
        IParcelService parcelService,
        ICoordinateService coordinateService,
        IWaterLogService waterLogService
    )
    {
        _parcelService = parcelService;
        _coordinateService = coordinateService;
        _waterLogService = waterLogService;
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

    [HttpGet("{parcelId:int}/coordinates")]
    [ProducesResponseType(type: typeof(IEnumerable<CoordinateInfoResponse>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCoordinatesForParcel([FromRoute] int parcelId) =>
        Ok(await _coordinateService.GetAllForParcel(parcelId));

    [HttpGet("{parcelId:int}/water-logs")]
    [Authorize(Policy = AuthorizationPolicies.ParcelOwnerOrAdmin)]
    [ProducesResponseType(typeof(IEnumerable<WaterLogInfoResponse>), statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWaterLogsForParcel([FromRoute] int parcelId) =>
        Ok(await _waterLogService.GetAllByParcelId(parcelId));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(type: typeof(CreateParcelResponse), statusCode: StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateParcelRequest request)
    {
        //TODO: URI
        return Created("", await _parcelService.CreateAsync(request));
    }

    [HttpPut("{parcelId:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateById([FromBody] UpdateParcelRequest request, [FromRoute] int parcelId)
    {
        await _parcelService.UpdateByIdAsync(request: request, parcelId: parcelId);
        return NoContent();
    }

    [HttpDelete("{parcelId:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteById([FromRoute] int parcelId)
    {
        await _parcelService.DeleteByIdAsync(parcelId);
        return NoContent();
    }
}