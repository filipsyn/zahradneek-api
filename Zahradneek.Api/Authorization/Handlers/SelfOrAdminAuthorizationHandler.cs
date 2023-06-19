using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Zahradneek.Api.Authorization.Requirements;

namespace Zahradneek.Api.Authorization.Handlers;

public class SelfOrAdminAuthorizationHandler : AuthorizationHandler<SelfOrAdminRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SelfOrAdminAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        SelfOrAdminRequirement requirement)
    {
        // Check for user role
        var currentUserRole = context.User.FindFirst(ClaimTypes.Role)?.Value ?? "User";
        if (currentUserRole == "Admin")
        {
            context.Succeed(requirement);
        }

        var httpContext = _httpContextAccessor.HttpContext;
        var accessedUserId = int.Parse((string)httpContext?.Request.RouteValues["userId"] ?? "0");
        var currentUserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        if (accessedUserId == currentUserId)
        {
            context.Succeed(requirement);
        }
    }
}