using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IFileResourceRepository
{
    Task<FileResource?> GetByIdAsync(Guid id);
    Task<IEnumerable<FileResource>> GetAllAsync();
    Task AddAsync(FileResource file);
    Task UpdateAsync(FileResource file);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<FileResource>> GetByUserIdAsync(Guid userId, CancellationToken ct = default);
}