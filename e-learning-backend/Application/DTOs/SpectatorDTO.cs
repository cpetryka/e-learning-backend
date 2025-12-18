namespace e_learning_backend.Infrastructure.Api.DTO;

public class SpectatorDTO
{
    public Guid Id { get; set; }     
    public string Email { get; set; } = string.Empty;
    public string? Status { get; set; }
}