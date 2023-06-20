using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Authorization;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Services.NewsService;

namespace Zahradneek.Api.Controllers.v1;

[ApiController]
[Route("/v1/news")]
[Produces("application/json")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(IEnumerable<NewsInfoResponse>), statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll() =>
        Ok(await _newsService.GetAllAsync());

    [HttpGet("{articleId:int}")]
    [ProducesResponseType(type: typeof(NewsInfoResponse), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int articleId) =>
        Ok(await _newsService.GetByIdAsync(articleId));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Create([FromBody] CreateNewsRequest request)
    {
        await _newsService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{articleId:int}")]
    [Authorize(Roles = AuthorizationPolicies.AuthorOrAdmin)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateById([FromBody] UpdateNewsRequest request, [FromRoute] int articleId)
    {
        await _newsService.UpdateByIdAsync(request: request, newsId: articleId);
        return NoContent();
    }

    [HttpDelete("{articleId:int}")]
    [Authorize(Roles = AuthorizationPolicies.AuthorOrAdmin)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteById([FromRoute] int articleId)
    {
        await _newsService.DeleteByIdAsync(articleId);
        return NoContent();
    }
}