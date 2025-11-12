namespace e_learning_backend.Infrastructure.Api.DTO;

public class QuizQuestionDTO
{
    public Guid? Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public List<QuestionCategoryDTO> Categories { get; set; } = new List<QuestionCategoryDTO>();
    public List<AnswerDTO>? Answers { get; set; } = new List<AnswerDTO>();
    public bool? Answered { get; set; }
}

public class AnswerDTO
{
    public Guid? Id { get; set; }
    public Guid? QuestionId { get; set; }
    public bool? Correct { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool? Selected { get; set; }
}

public class QuestionCategoryDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}