namespace e_learning_backend.Infrastructure.Api.DTO;

public class StudentBriefDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
}