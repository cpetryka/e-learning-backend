namespace e_learning_backend.Infrastructure.Api.DTO;

public class AddClassForExistingParticipationDTO
{
    public Guid CourseId { get; set; }
    public DateTime StartTime { get; set; }
}