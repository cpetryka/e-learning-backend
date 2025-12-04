namespace e_learning_backend.Infrastructure.Api.DTO;

public class AddClassForExistingParticipationDTO
{
    public Guid CourseVariantId { get; set; }
    public DateTime StartTime { get; set; }
}