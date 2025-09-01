namespace e_learning_backend.Infrastructure.Api.DTO;

public class TeacherDTO
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Description { get; set; }
    public List<CourseBriefDTO> CoursesBrief { get; set; } = new();

    public class CourseBriefDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
    
}