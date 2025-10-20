namespace e_learning_backend.Application.Files
{
    /// <summary>
    /// Defines an abstraction over the physical file storage system.
    /// </summary>
    public interface IFileStorage
    {
        Task SaveAsync(string relativePath, Stream content, CancellationToken ct = default);
        
        Task<IReadOnlyList<(string RelativePath, string Name)>> ListAsync(string userFolder, CancellationToken ct = default);
        
        Task DeleteAsync(string relativePath, CancellationToken ct = default);
    }
}