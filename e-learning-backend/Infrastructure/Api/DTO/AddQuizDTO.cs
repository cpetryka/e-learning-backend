namespace e_learning_backend.Infrastructure.Api.DTO;

public class AddQuizDTO
{
    public string Name { get; set; } = string.Empty;
    public Guid ClassId { get; set; }
    public List<Guid> QuestionIds { get; set; } = new();
    public bool IsMultipleChoice { get; set; }
    public decimal MaxScore { get; set; }
}