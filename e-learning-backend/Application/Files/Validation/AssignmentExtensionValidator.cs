using e_learning_backend.Application.Files.Validation.Interfaces;

namespace e_learning_backend.Application.Files.Validation;


/// <summary>
/// Provides file extension validation for general user uploads such as assignments,
/// documents, archives, images, and code files.
/// </summary>
public class AssignmentExtensionValidator : IFileExtensionValidator.IAssignmentExtensionValidator
{
    private static readonly HashSet<string> _allowed = new(StringComparer.OrdinalIgnoreCase)
    {
        ".pdf",".doc",".docx",".odt",".rtf",".txt",".md",
        ".ppt",".pptx",".odp",".xls",".xlsx",".ods",".csv",
        ".zip",".7z",
        ".png",".jpg",".jpeg",".gif",
        ".cs",".java",".py",".cpp",".c",".js",".ts",".ipynb"
    };
    
    public bool IsAllowed(string extension) => _allowed.Contains(extension ?? string.Empty);
    
    public IReadOnlyCollection<string> Allowed => _allowed;
}