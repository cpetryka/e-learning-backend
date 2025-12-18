namespace e_learning_backend.Infrastructure.Api.DTO;

public class QuestionSolutionDTO
{
    public Guid QuestionId { get; set; }
    public List<Guid> SelectedAnswerIds { get; set; } = new();
}