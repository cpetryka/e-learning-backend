namespace e_learning_backend.Domain.Users.ValueObjects;

public class ProfilePicture
{
    public string FileName { get; private set; }
    public string FilePath { get; private set; }
    public DateTime UploadedAt { get; private set; }

    private ProfilePicture() { }

    public ProfilePicture(string fileName, string filePath)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File name cannot be empty.", nameof(fileName));

        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path cannot be empty.", nameof(filePath));
        
        FileName = fileName;
        FilePath = filePath;
        UploadedAt = DateTime.UtcNow;
    }
}