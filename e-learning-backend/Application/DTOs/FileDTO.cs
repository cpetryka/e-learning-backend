
public class FileDTO
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string RelativePath { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
    
    public FileDTO() { }

    public FileDTO(Guid id, string name, string relativePath, DateTime addedAt)
    {
        Id = id;
        FileName = name;
        RelativePath = relativePath;
        UploadedAt = addedAt;
    }
}