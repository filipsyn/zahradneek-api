using Microsoft.AspNetCore.Mvc;
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
}