namespace e_learning_backend.Infrastructure.Api.DTO;

public class StudentDTO
{
    public string Name { get; set; } = string.Empty;
    public List<CourseBriefDTO> CoursesBrief { get; set; } = new();

    public class CourseBriefDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
