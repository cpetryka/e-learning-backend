using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(Guid id);
    Task<IEnumerable<Course>> GetAllAsync();
    Task<IReadOnlyCollection<CourseCategory>> GetAllDistinctCategoriesAsync();
    Task<IReadOnlyCollection<CourseLevel>> GetAllDistinctLevelsAsync();
    Task<IReadOnlyCollection<CourseLanguage>> GetAllDistinctLanguagesAsync();
    Task AddAsync(Course course);
    Task UpdateAsync(Course course);
    Task DeleteAsync(Guid id);
    IQueryable<Course> GetAllQueryable();
}