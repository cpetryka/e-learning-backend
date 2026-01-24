namespace e_learning_backend.Infrastructure.Persistence.Services.DTO;

/// <summary>
/// DTO representing the result of an authentication/authorization request.
/// </summary>
/// <remarks>
/// This object is used as a unified response for login, registration, and token refresh operations.
/// </remarks>
public class AuthorizationResultDto
{
    public bool Success { get; set; }
    public string[] Errors { get; set; } = null!;
    public string AccessToken { get; set; }
    
    public string? UserId { get; set; }
    public IEnumerable<string>? Roles { get; set; }
    public string RefreshToken { get; set; }
}