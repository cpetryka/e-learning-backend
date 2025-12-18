namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetClassFileDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string AssociatedCourseName { get; set; } = string.Empty;
    public DateTime AssociatedClassDate { get; set; }
}