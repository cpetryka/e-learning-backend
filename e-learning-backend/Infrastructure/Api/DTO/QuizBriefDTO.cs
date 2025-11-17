namespace e_learning_backend.Infrastructure.Api.DTO;

public class QuizBriefDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public int QuestionNumber { get; set; }
    public bool Completed { get; set; }
}