
using e_learning_backend.Application.Files;
using Microsoft.Extensions.Options;

namespace e_learning_backend.Infrastructure.FileStorage
{
    /// <summary>
    /// Provides a local-disk implementation of <see cref="IFileStorage"/> that stores files 
    /// in a designated root directory (e.g., <c>wwwroot/uploads</c>).
    /// </summary>
    public sealed class LocalDiskFileStorage : IFileStorage
    {
        private readonly string _rootPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalDiskFileStorage"/> class.
        /// </summary>
        /// <param name="options">File upload configuration containing the root upload path.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <see cref="FileUploadOptions.RootPath"/> is <c>null</c> or not configured.
        /// </exception>
        public LocalDiskFileStorage(IOptions<FileUploadOptions> options)
        {
            _rootPath = options.Value.RootPath
                        ?? throw new InvalidOperationException("FileUploadOptions.RootPath cannot be null.");
        }

        /// <summary>
        /// Saves a file asynchronously to the local disk storage under the specified relative path.
        /// </summary>
        /// <param name="relativePath">The relative path (within the root folder) where the file will be saved.</param>
        /// <param name="content">The stream containing the file content.</param>
        /// <param name="ct">Optional cancellation token to abort the operation.</param>
        /// <remarks>
        /// The method automatically creates any missing directories and writes the file asynchronously.
        /// Existing files with the same name will cause an <see cref="IOException"/> because 
        /// the file mode is set to <see cref="FileMode.CreateNew"/>.
        /// </remarks>
        public async Task SaveAsync(string relativePath, Stream content, CancellationToken ct = default)
        {
            var fullPath = Path.Combine(_rootPath, relativePath.Replace('\\', '/'));
            var dir = Path.GetDirectoryName(fullPath)!;

            Directory.CreateDirectory(dir);

            await using var fs = new FileStream(
                fullPath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                64 * 1024,
                useAsync: true);

            await content.CopyToAsync(fs, ct);
        }

        /// <summary>
        /// Lists all files from the specified folder within the storage root.
        /// </summary>
        /// <param name="userFolder">The relative folder path to list files from.</param>
        /// <param name="ct">Optional cancellation token to abort the operation.</param>
        
        public Task<IReadOnlyList<(string RelativePath, string Name)>> ListAsync(string userFolder, CancellationToken ct = default)
        {
            var folder = Path.Combine(_rootPath, userFolder.Replace('\\', '/'));

            if (!Directory.Exists(folder))
                return Task.FromResult<IReadOnlyList<(string, string)>>(Array.Empty<(string, string)>());

            var files = Directory.GetFiles(folder)
                .Select(p => (
                    RelativePath: Path.GetRelativePath(_rootPath, p).Replace('\\', '/'),
                    Name: Path.GetFileName(p)))
                .ToList();

            return Task.FromResult<IReadOnlyList<(string, string)>>(files);
        }

        /// <summary>
        /// Deletes a file asynchronously from the local disk storage.
        /// </summary>
        /// <param name="relativePath">The relative path of the file to delete (within the root directory).</param>
        /// <param name="ct">Optional cancellation token to abort the operation.</param>
        
        public Task DeleteAsync(string relativePath, CancellationToken ct = default)
        {
            var fullPath = Path.Combine(_rootPath, relativePath.Replace('\\', '/'));

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }
    }
}
