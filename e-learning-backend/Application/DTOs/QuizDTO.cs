namespace e_learning_backend.Infrastructure.Api.DTO;

public class QuizDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ClassId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public Guid TeacherId { get; set; }
    public Guid StudentId { get; set; }
    public bool IsMultipleChoice { get; set; }
    public double? Score { get; set; }
    public double MaxScore { get; set; }
}