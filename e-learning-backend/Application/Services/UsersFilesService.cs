
using System.Text.RegularExpressions;
using e_learning_backend.Application.Files;
using e_learning_backend.Application.Files.Validation.Interfaces;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Options;

namespace e_learning_backend.Application.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for handling user file uploads and profile picture management.
    /// </summary>
    public class UsersFilesService : IUsersFilesService
    {
        private readonly IFileStorage _storage;
        private readonly IUsersRepository _repo;
        private readonly IFileExtensionValidator.IAssignmentExtensionValidator _assignmentValidator;
        private readonly IFileExtensionValidator.IProfilePictureExtensionValidator _profilePicValidator;
        private readonly FileUploadOptions _opts;
        private readonly IFileResourceRepository _fileResourceRepo;

        public UsersFilesService(
            IFileStorage storage,
            IUsersRepository repo,
            IFileExtensionValidator.IAssignmentExtensionValidator assignmentValidator,
            IFileResourceRepository fileResourceRepo,
            IOptions<FileUploadOptions> opts,
            IFileExtensionValidator.IProfilePictureExtensionValidator profilePicValidator)
        {
            _storage = storage;
            _repo = repo;
            _assignmentValidator = assignmentValidator;
            _opts = opts.Value;
            _fileResourceRepo = fileResourceRepo;
            _profilePicValidator = profilePicValidator;
        }

        /// <summary>
        /// Retrieves all uploaded files for a given user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="ct">Cancellation token for asynchronous operations.</param>
        /// <returns>A read-only list of file DTOs sorted by upload date descending.</returns>
        /// <exception cref="ArgumentException">Thrown if user ID is invalid.</exception>
        public async Task<IReadOnlyList<FileDTO>> GetUserFilesAsync(Guid userId, CancellationToken ct = default)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid user identifier.", nameof(userId));

            var files = await _fileResourceRepo.GetByUserIdAsync(userId, ct);

            return files
                .OrderByDescending(f => f.AddedAt)
                .Select(f => new FileDTO
                {
                    Id = f.Id,
                    FileName = f.Name,
                    RelativePath = $"/uploads/{f.Path}",
                    UploadedAt = f.AddedAt
                })
                .ToList();
        }

        /// <summary>
        /// Uploads a general file for a specific user (assignment, material, etc.).
        /// </summary>
        /// <param name="userId">The unique identifier of the user uploading the file.</param>
        /// <param name="file">The uploaded file.</param>
        /// <param name="ct">Cancellation token for asynchronous operations.</param>
        /// <returns>A DTO containing information about the uploaded file.</returns>
        /// <exception cref="ArgumentException">Thrown if the user ID is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the file is invalid or violates upload rules.</exception>
        public async Task<UserFileUploadResultDTO> UploadAsync(Guid userId, IFormFile file, CancellationToken ct = default)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid user identifier.", nameof(userId));

            if (file is null || file.Length == 0)
                throw new InvalidOperationException("No file uploaded or file is empty.");

            if (file.Length > _opts.MaxBytes)
                throw new InvalidOperationException($"File exceeds the maximum allowed size of {_opts.MaxBytes / (1024 * 1024)} MB.");

            var ext = Path.GetExtension(file.FileName)?.ToLowerInvariant() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ext) || !_assignmentValidator.IsAllowed(ext))
                throw new InvalidOperationException($"File extension not allowed: {ext}");

            var safeName = SanitizeFileName(Path.GetFileNameWithoutExtension(file.FileName)) + ext;

            var user = await _repo.GetByIdAsync(userId)
                       ?? throw new InvalidOperationException("User not found.");

            var fileId = Guid.NewGuid();

            // Relative path under "uploads" directory
            var relativePathWithinUploads = Path
                .Combine("users", userId.ToString(), "files", $"{fileId}{ext}")
                .Replace('\\', '/');

            // Save file to storage
            await using (var stream = file.OpenReadStream())
            {
                await _storage.SaveAsync(relativePathWithinUploads, stream, ct);
            }

            // Create entity and persist in the database
            var entity = new FileResource(
                id: fileId,
                name: safeName,
                path: relativePathWithinUploads,
                addedAt: DateTime.UtcNow,
                user: user);

            await _fileResourceRepo.AddAsync(entity);

            // Return DTO for frontend
            return new UserFileUploadResultDTO(
                id: entity.Id,
                name: entity.Name,
                relativePath: $"/uploads/{entity.Path}",
                sizeBytes: file.Length);
        }

        /// <summary>
        /// Uploads or updates a user's profile picture.
        /// </summary>
        /// <param name="userId">The unique identifier of the user uploading the profile picture.</param>
        /// <param name="file">The profile picture file.</param>
        /// <param name="ct">Cancellation token for asynchronous operations.</param>
        /// <returns>A DTO containing information about the uploaded profile picture.</returns>
        /// <exception cref="ArgumentException">Thrown if the user ID is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the file is invalid or violates profile picture rules.</exception>
        public async Task<UserFileUploadResultDTO> UploadProfilePictureAsync(Guid userId, IFormFile file, CancellationToken ct = default)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid user identifier.", nameof(userId));

            if (file is null || file.Length == 0)
                throw new InvalidOperationException("No file uploaded or file is empty.");

            if (file.Length > 5 * 1024 * 1024) // 5 MB limit
                throw new InvalidOperationException("File exceeds the maximum allowed size of 5 MB.");

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_profilePicValidator.IsAllowed(ext))
                throw new InvalidOperationException($"File extension not allowed: {ext}");

            var user = await _repo.GetByIdAsync(userId)
                       ?? throw new InvalidOperationException("User not found.");

            var fileName = $"profile-picture{ext}";

            // Relative path under "uploads" directory
            var relativePathWithinUploads = Path
                .Combine("users", userId.ToString(), fileName)
                .Replace('\\', '/');

            // Save the profile picture to storage
            await using (var stream = file.OpenReadStream())
            {
                await _storage.SaveAsync(relativePathWithinUploads, stream, ct);
            }

            // Create the ProfilePicture value object and update user
            var profilePicture = new ProfilePicture(
                fileName,
                Path.Combine("uploads", "users", userId.ToString(), fileName).Replace('\\', '/')
            );

            user.SetProfilePicture(profilePicture);
            await _repo.UpdateAsync(user);

            // Return DTO for frontend
            return new UserFileUploadResultDTO(
                id: Guid.NewGuid(),
                name: fileName,
                relativePath: $"/uploads/{relativePathWithinUploads}",
                sizeBytes: file.Length
            );
        }

        /// <summary>
        /// Sanitizes a file name by replacing disallowed characters with underscores.
        /// </summary>
        /// <param name="name">The original file name without extension.</param>
        /// <returns>A sanitized, safe file name.</returns>
        private static string SanitizeFileName(string name)
        {
            var cleaned = Regex.Replace(name ?? string.Empty, @"[^\w\-. ]+", "_");
            cleaned = cleaned.Trim();
            return string.IsNullOrWhiteSpace(cleaned) ? "file" : cleaned;
        }
    }
}
