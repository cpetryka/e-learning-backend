namespace e_learning_backend.Infrastructure.Api.DTO;

public class TeacherReviewDTO
{
    public string ReviewerName { get; set; }
    public string ReviewerSurname { get; set; }
    public int StarsNumber { get; set; }
    public string Content { get; set; } = null!;
}