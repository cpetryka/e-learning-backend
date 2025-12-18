namespace e_learning_backend.Infrastructure.Api.DTO;

public class AddExerciseDTO
{
    public Guid ClassId { get; set; }
    public string Instructions { get; set; } = string.Empty;
    public IEnumerable<Guid>? FileIds { get; set; }
}