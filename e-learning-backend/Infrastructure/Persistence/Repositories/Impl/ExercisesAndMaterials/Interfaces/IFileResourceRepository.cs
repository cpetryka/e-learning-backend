using e_learning_backend.Domain.ExercisesAndMaterials;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IFileResourceRepository
{
    Task<FileResource?> GetByIdAsync(Guid id);
    Task<IEnumerable<FileResource>> GetAllAsync();
    Task AddAsync(FileResource file);
    Task UpdateAsync(FileResource file);
    Task DeleteAsync(Guid id);
}