namespace e_learning_backend.Infrastructure.Api.DTO;

public class QuizSolutionDTO
{
    public Guid QuizId { get; set; }
    public List<QuestionSolutionDTO> Answers { get; set; } = new();
}