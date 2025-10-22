using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Application.Services;

public interface IUsersFilesService
{
    Task<IReadOnlyList<FileDTO>> GetUserFilesAsync(Guid userId, CancellationToken ct = default);
    Task<UserFileUploadResultDTO> UploadAsync(Guid userId, IFormFile file, CancellationToken ct = default);

    Task<UserFileUploadResultDTO> UploadProfilePictureAsync(Guid userId, IFormFile file, CancellationToken ct = default);
}