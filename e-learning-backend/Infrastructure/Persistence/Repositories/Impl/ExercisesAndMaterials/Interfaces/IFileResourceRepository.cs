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
    Task<List<GetFileDTO>> GetByUserIdAsync(Guid userId, CancellationToken ct = default);
    Task<List<string>> GetFileExtensionsByUserIdAsync(Guid userId, CancellationToken ct = default);
    Task<List<ClassFileOwnerDTO>> GetClassFileOwnersAsync(Guid userId, CancellationToken ct = default);
}