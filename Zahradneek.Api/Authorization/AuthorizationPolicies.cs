namespace Zahradneek.Api.Authorization;

public static class AuthorizationPolicies
{
    public const string ParcelOwnerOrAdmin = "ParcelOwnerOrAdmin";
    public const string SelfOrAdmin = "SelfOrAdmin";
}