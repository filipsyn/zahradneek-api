using Microsoft.AspNetCore.Mvc;
using Zahradneek.Api.Contracts.v1.Requests;
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
    public async Task<IActionResult> GetAll() =>
        Ok(await _newsService.GetAllAsync());

    [HttpGet("{articleId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int articleId) =>
        Ok(await _newsService.GetByIdAsync(articleId));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNewsRequest request)
    {
        await _newsService.CreateAsync(request);
        return NoContent();
    }

    [HttpPut("{articleId:int}")]
    public async Task<IActionResult> UpdateById([FromBody] UpdateNewsRequest request, [FromRoute] int articleId)
    {
        await _newsService.UpdateByIdAsync(request: request, newsId: articleId);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteById([FromRoute] int articleId)
    {
        await _newsService.DeleteByIdAsync(articleId);
        return NoContent();
    }
}