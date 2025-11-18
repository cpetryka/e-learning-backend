using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IFileResourceRepository
{
    Task<FileResource?> GetByIdAsync(Guid id);
    Task<IEnumerable<FileResource>> GetAllAsync();
    Task AddAsync(FileResource file);
    Task<bool> DeleteFileAsync(Guid id,CancellationToken ct = default);

    Task<(List<GetFileDTO>, int TotalCount)> GetFilesConnectedToUser(
        Guid userId,
        IEnumerable<Guid>? tagIds = null,
        IEnumerable<string>? types = null,
        Guid? studentId = null,
        Guid? courseId = null,
        IEnumerable<Guid>? ownerIds = null,
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default);
    Task<List<string>> GetFileExtensionsByUserIdAsync(Guid userId, CancellationToken ct = default);
    Task<List<ClassFileOwnerDTO>> GetClassFileOwnersAsync(Guid userId, CancellationToken ct = default);
}