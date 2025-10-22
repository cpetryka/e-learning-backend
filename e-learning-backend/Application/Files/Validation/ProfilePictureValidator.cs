using e_learning_backend.Application.Files.Validation.Interfaces;

namespace e_learning_backend.Application.Files.Validation;


/// <summary>
/// Provides file extension validation for user profile picture uploads.
/// </summary>
public class ProfilePictureValidator : IFileExtensionValidator.IProfilePictureExtensionValidator
{
    private static readonly HashSet<string> _allowed = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".webp"
    };

    public bool IsAllowed(string extension) => _allowed.Contains(extension ?? string.Empty);

    public IReadOnlyCollection<string> Allowed => _allowed;
}