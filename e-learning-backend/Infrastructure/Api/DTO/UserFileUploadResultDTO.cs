namespace e_learning_backend.Infrastructure.Api.DTO;

public class UserFileUploadResultDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RelativePath { get; set; } = string.Empty;
    public long SizeBytes { get; set; }

    public UserFileUploadResultDTO() { }
    public UserFileUploadResultDTO(Guid id, string name, string relativePath, long sizeBytes)
    {
        Id = id; Name = name; RelativePath = relativePath; SizeBytes = sizeBytes;
    }
}