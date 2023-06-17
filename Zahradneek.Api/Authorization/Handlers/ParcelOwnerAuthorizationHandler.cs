using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Zahradneek.Api.Authorization.Requirements;
using Zahradneek.Api.Repositories.ParcelRepository;

namespace Zahradneek.Api.Authorization.Handlers;

public class ParcelOwnerAuthorizationHandler : AuthorizationHandler<ParcelOwnerRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IParcelRepository _parcelRepository;

    public ParcelOwnerAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IParcelRepository parcelRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _parcelRepository = parcelRepository;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ParcelOwnerRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var parcelId = int.Parse((string) httpContext?.Request.RouteValues["parcelId"] ?? "0");
        var userId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");


        if (await _parcelRepository.IsOwner(userId, parcelId))
        {
            context.Succeed(requirement);
        }
    }
}