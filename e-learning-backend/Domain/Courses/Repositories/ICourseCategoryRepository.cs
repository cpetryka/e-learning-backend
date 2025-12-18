using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ICourseCategoryRepository
{
    Task<CourseCategory?> GetByIdAsync(Guid id);
    Task<IEnumerable<CourseCategory>> GetAllAsync();
    Task AddAsync(CourseCategory category);
    Task UpdateAsync(CourseCategory category);
    Task DeleteAsync(Guid id);
}