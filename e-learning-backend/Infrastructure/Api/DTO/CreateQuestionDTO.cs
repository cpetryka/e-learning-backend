namespace e_learning_backend.Infrastructure.Api.DTO;

public class CreateQuestionDTO
{
    public string Content { get; set; } = string.Empty;
    public List<CreateAnswerDTO> Answers { get; set; } = new List<CreateAnswerDTO>();
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
}