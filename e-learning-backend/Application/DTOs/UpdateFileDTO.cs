namespace e_learning_backend.Infrastructure.Api.DTO;

public class UpdateFileDTO
{
    public string FileName { get; set; } = string.Empty;
    public List<FileTagDTO> Tags { get; set; } = new();
}

public class FileTagDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }
}

