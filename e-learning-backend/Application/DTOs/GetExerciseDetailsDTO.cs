namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetExerciseDetailsDTO
{
    public Guid ExerciseId { get; set; }
    public double? Grade { get; set; }       
    public string? Comment { get; set; }
    public Guid TeacherId { get; set; }
}