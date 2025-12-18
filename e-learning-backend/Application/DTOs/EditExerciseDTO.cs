namespace e_learning_backend.Infrastructure.Api.DTO;

public class EditExerciseDTO
{
    public string? Instructions { get; set; }
    public IEnumerable<Guid>? FileIds { get; set; }
}