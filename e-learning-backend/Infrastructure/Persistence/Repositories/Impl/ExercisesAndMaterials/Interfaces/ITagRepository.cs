using e_learning_backend.Domain.ExercisesAndMaterials;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tag>> GetAllAsync();
    Task AddAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Tag>> GetByTeacherIdAsync(Guid teacherId);
}