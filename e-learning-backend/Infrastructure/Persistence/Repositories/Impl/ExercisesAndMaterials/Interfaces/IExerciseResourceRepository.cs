using e_learning_backend.Domain.ExercisesAndMaterials;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IExerciseResourceRepository
{
    Task<ExerciseResource?> GetByIdsAsync(Guid exerciseId, Guid fileId);
    Task<IEnumerable<ExerciseResource>> GetAllAsync();
    Task AddAsync(ExerciseResource resource);
    Task UpdateAsync(ExerciseResource resource);
    Task DeleteAsync(Guid exerciseId, Guid fileId);
}