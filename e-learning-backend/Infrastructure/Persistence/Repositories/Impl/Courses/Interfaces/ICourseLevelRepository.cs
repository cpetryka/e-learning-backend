using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ICourseLevelRepository
{
    Task<CourseLevel?> GetByIdAsync(Guid id);
    Task<IEnumerable<CourseLevel>> GetAllAsync();
    Task AddAsync(CourseLevel level);
    Task UpdateAsync(CourseLevel level);
    Task DeleteAsync(Guid id);
}