using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ICourseVariantRepository
{
    Task<CourseVariant?> GetByIdAsync(Guid id);
    Task<IEnumerable<CourseVariant>> GetAllAsync();
    Task AddAsync(CourseVariant variant);
    Task UpdateAsync(CourseVariant variant);
    Task DeleteAsync(Guid id);
    Task<CourseVariant?> GetByAttributesAsync(Guid courseId, Guid levelId, Guid languageId);
}