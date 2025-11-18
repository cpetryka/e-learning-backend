using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Application.Services;

public interface IUsersFilesService
{
    Task<UserFileUploadResultDTO> UploadAsync(Guid userId, IFormFile file, CancellationToken ct = default);

    Task<UserFileUploadResultDTO> UploadProfilePictureAsync(Guid userId, IFormFile file, CancellationToken ct = default);

    Task<PagedResult<GetFileDTO>> GetUserFilesAsync(
        Guid userId,
        IEnumerable<Guid>? tags = null,
        IEnumerable<string>? fileTypes = null,
        Guid? studentId = null,
        Guid? courseId = null,
        IEnumerable<Guid>? ownerId = null,
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default);

    Task<IEnumerable<GetFileDTO.TagDTO>> GetUserFileTags(Guid userId, CancellationToken ct = default);
    Task<bool> DeleteFile(Guid userId, Guid fileId, CancellationToken ct = default);
    Task<List<string>> GetFileExtensionsByUserIdAsync(Guid userId, CancellationToken ct = default);
    Task<List<ClassFileOwnerDTO>> GetClassFileOwnersAsync(Guid userId, CancellationToken ct = default);
}