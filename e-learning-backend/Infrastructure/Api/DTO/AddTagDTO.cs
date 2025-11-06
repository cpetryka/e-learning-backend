namespace e_learning_backend.Infrastructure.Api.DTO;

public class AddTagDTO
{
    public string Name { get; set; } = string.Empty;
    public Guid AddedById { get; set; }
}