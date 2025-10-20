namespace e_learning_backend.Infrastructure.Api.DTO;

public class UserFileUploadDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RelativePath { get; set; } = string.Empty;
    public DateTime AddedAt { get; set; }

    public UserFileUploadDTO() { }

    public UserFileUploadDTO(Guid id, string name, string relativePath, DateTime addedAt)
    {
        Id = id;
        Name = name;
        RelativePath = relativePath;
        AddedAt = addedAt;
    }
}