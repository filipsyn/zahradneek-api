using Microsoft.AspNetCore.Mvc;
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
}