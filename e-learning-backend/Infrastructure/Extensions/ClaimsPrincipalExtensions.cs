using System.Security.Claims;

namespace e_learning_backend.Infrastructure.Extensions;

public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Retrieves the user ID from the claims principal.
    /// </summary>
    /// <param name="user">The claims principal containing user information.</param>
    /// <returns>The user ID as a <see cref="Guid"/> if found and valid; otherwise, <c>null</c>.</returns>
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var idValue = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(idValue, out var userId))
            return userId;

        return null;
    }
}