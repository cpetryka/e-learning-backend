namespace e_learning_backend.Infrastructure.Api.DTO;

public class EditQuizDTO
{
    public string? Name { get; set; }
    public IEnumerable<Guid>? QuestionIds { get; set; }
}