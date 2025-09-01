using e_learning_backend.Infrastructure.Api.DTO;

public class CourseDetailsDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Image { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; } = null!;
    public IEnumerable<CourseWidgetDTO.CourseVariantDTO> Variants { get; set; } = new List<CourseWidgetDTO.CourseVariantDTO>();
    public TeacherDTO Teacher { get; set; } = null!;
    public List<TeacherReviewDTO> TeacherReviews { get; set; } = new();
    public List<TeacherAvailabilityDTO> TeacherAvailability { get; set; } = new();
    public string? Category { get; set; }
}