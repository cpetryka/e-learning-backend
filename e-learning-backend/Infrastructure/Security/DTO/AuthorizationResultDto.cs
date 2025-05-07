namespace e_learning_backend.Infrastructure.Persistence.Services.DTO;

public class AuthorizationResultDto
{
    public bool Success { get; set; }
    public string[] Errors { get; set; } = null!;
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}