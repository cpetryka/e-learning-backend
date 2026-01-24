namespace e_learning_backend.Infrastructure.Persistence.Services.DTO;

/// <summary>
/// DTO for user registration.
/// Contains personal details, credentials, and the requested account role.
/// </summary>
public class RegisterUserDto
{
    public string Email    { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public string AboutMe { get; init; } = string.Empty;

    /// <summary>
    ///   Optional. If "Teacher" (case‐insensitive), we register as Teacher, otherwise Student.
    /// </summary>
    public string AccountType { get; init; }
}