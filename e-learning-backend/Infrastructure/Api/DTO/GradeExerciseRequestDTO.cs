namespace e_learning_backend.Infrastructure.Api.DTO;

public class GradeExerciseRequestDTO
{
    public Guid AssignmentId { get; set; }
    public double Grade { get; set; }
    public string? Comments { get; set; }
}