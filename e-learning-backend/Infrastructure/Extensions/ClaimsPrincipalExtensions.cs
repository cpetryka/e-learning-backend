using System.Security.Claims;

namespace e_learning_backend.Infrastructure.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var idValue = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(idValue, out var userId))
            return userId;

        return null;
    }
}