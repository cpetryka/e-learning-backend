namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetClassLinkDTO
{
    public Guid? Id { get; set; }
    public string Path { get; set; } = string.Empty;
    public bool? IsMeeting { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string? ClassName { get; set; }
}