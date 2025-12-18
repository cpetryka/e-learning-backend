namespace e_learning_backend.Infrastructure.Api.DTO;

public class QuizSummaryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}