namespace e_learning_backend.Infrastructure.Api.Controllers;

public class AddClassWithParticipationDTO
{
    public Guid CourseId { get; set; } 
    public DateTime StartTime { get; set; }
    // The two properties below are optional (used only if a new Participation needs to be created)
    public Guid? LanguageId { get; set; } 
    public Guid? LevelId { get; set; } 
}