using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Zahradneek.Api.Authorization.Requirements;
using Zahradneek.Api.Repositories.NewsRepository;

namespace Zahradneek.Api.Authorization.Handlers;

public class AuthorOrAdminAuthorizationHandler : AuthorizationHandler<AuthorOrAdminRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly INewsRepository _newsRepository;

    public AuthorOrAdminAuthorizationHandler(IHttpContextAccessor httpContextAccessor, INewsRepository newsRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _newsRepository = newsRepository;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        AuthorOrAdminRequirement requirement)
    {
        var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value ?? "User";

        if (userRole == "Admin")
        {
            context.Succeed(requirement);
        }

        var httpContext = _httpContextAccessor.HttpContext;
        var articleId = int.Parse((string)httpContext?.Request.RouteValues["articleId"] ?? "0");
        var userId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        if (await _newsRepository.IsAuthor(userId, articleId))
        {
            context.Succeed(requirement);
        }
    }
}