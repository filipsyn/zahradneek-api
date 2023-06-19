using Microsoft.AspNetCore.Authorization;

namespace Zahradneek.Api.Authorization.Requirements;

public class SelfOrAdminRequirement : IAuthorizationRequirement
{
}