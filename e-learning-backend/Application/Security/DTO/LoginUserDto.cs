namespace e_learning_backend.Infrastructure.Persistence.Services.DTO;

/// <summary>
/// DTO for user login-in.
/// Contains email and password.
/// </summary>
public class LoginUserDto
{
    public string Email    { get; init; } = null!;
    public string Password { get; init; } = null!;
}