using e_learning_backend.Infrastructure.Api.DTO;

public class CourseDetailsDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public string? Category { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; } = null!;
    public TeacherDTO Teacher { get; set; } = null!;
    public IEnumerable<CourseVariantDTO> Variants { get; set; } = new List<CourseVariantDTO>();
    
}