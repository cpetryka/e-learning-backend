namespace e_learning_backend.API.DTOs;


public sealed class ClassDTO
{
    public DateTime StartTime { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public Guid TeacherId { get; set; }
}