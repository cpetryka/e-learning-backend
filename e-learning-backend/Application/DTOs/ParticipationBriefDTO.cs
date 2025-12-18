namespace e_learning_backend.Infrastructure.Api.DTO;

public class ParticipationBriefDTO
{
    public Guid CourseId { get; set; }
    public Guid UserId { get; set; }
    public string CourseName { get; set; }
}