namespace e_learning_backend.Infrastructure.Api.DTO;

public class CreateAnswerDTO
{
    public string Content { get; set; } = string.Empty;
    public bool Correct { get; set; }
}