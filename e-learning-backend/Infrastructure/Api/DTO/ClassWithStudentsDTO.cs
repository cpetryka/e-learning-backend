namespace e_learning_backend.Infrastructure.Api.DTO;

public class ClassWithStudentsDTO
{
     public Guid CourseId { get; set; }
    public string CourseName { get; set; } = default!;
    public List<StudentBriefDTO> Students { get; set; } = new();
}