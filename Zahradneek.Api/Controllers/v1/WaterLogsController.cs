using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Services.WaterLogService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("v1/water-logs")]
[Produces("application/json")]
public class WaterLogsController : ControllerBase
{
    private readonly IWaterLogService _waterLogService;

    public WaterLogsController(IWaterLogService waterLogService)
    {
        _waterLogService = waterLogService;
    }

    [HttpGet]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<WaterLogInfoResponse>))]
    public async Task<IActionResult> GetAll() => Ok(await _waterLogService.GetAllAsync());

    [HttpGet("{waterLogId:int}")]
    [ProducesResponseType(type: typeof(WaterLogInfoResponse), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int waterLogId)
        => Ok(await _waterLogService.GetByIdAsync(waterLogId));

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Create([FromBody] CreateWaterLogRequest request)
    {
        await _waterLogService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{waterLogId:int}")]
    public async Task<IActionResult> UpdateById([FromBody] UpdateWaterLogRequest request, [FromRoute] int waterLogId)
    {
        await _waterLogService.UpdateByIdAsync(request: request, waterLogId: waterLogId);
        return NoContent();
    }

    [HttpDelete("{waterLogId:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int waterLogId)
    {
        await _waterLogService.DeleteByIdAsync(waterLogId);
        return NoContent();
    }
}