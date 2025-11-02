namespace e_learning_backend.Infrastructure.Api.DTO;

public class TeacherUpcomingClass
{
    public Guid ClassId { get; set; }
    public Guid StudentId { get; set; }
    public String StudentName { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public DateOnly ClassDate { get; set; }
    public TimeOnly ClassStartTime { get; set; }
    public TimeOnly ClassEndTime { get; set; }
}