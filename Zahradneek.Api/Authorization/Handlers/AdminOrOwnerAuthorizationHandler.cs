using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Zahradneek.Api.Authorization.Requirements;
using Zahradneek.Api.Repositories.ParcelRepository;

namespace Zahradneek.Api.Authorization.Handlers;

public class AdminOrOwnerAuthorizationHandler : AuthorizationHandler<AdminOrOwnerRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IParcelRepository _parcelRepository;

    public AdminOrOwnerAuthorizationHandler(IHttpContextAccessor httpContextAccessor,
        IParcelRepository parcelRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _parcelRepository = parcelRepository;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        AdminOrOwnerRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var parcelId = int.Parse((string)httpContext?.Request.RouteValues["parcelId"] ?? "0");
        var userId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value ?? "User";

        if (userRole == "Admin")
        {
            context.Succeed(requirement);
        }

        if (await _parcelRepository.IsOwner(userId, parcelId))
        {
            context.Succeed(requirement);
        }
    }
}