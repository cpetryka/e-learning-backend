namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetExerciseResourceDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
}