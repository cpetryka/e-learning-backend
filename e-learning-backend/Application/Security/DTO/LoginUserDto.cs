namespace e_learning_backend.Infrastructure.Persistence.Services.DTO;

public class LoginUserDto
{
    public string Email    { get; init; } = null!;
    public string Password { get; init; } = null!;
}