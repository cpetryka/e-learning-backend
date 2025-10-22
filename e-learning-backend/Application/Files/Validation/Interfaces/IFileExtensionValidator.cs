namespace e_learning_backend.Application.Files.Validation.Interfaces;

public interface IFileExtensionValidator
{
    bool IsAllowed(string extension);
    IReadOnlyCollection<string> Allowed { get; }
    
    /// <summary>
    /// Specialized interface for validating general user file uploads (assignments, documents, etc.).
    /// </summary>
    public interface IAssignmentExtensionValidator : IFileExtensionValidator { }

    /// <summary>
    /// Specialized interface for validating profile picture uploads.
    /// </summary>
    public interface IProfilePictureExtensionValidator : IFileExtensionValidator { }
}