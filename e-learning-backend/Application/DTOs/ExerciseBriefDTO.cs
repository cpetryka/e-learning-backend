namespace e_learning_backend.Infrastructure.Api.DTO;

public class ExerciseBriefDTO
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public String CourseName { get; set; }
    public DateTime ClassStartTime { get; set; }
    public string ExerciseStatus { get; set; } = default!;
}