using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ICourseLanguageRepository
{
    Task<CourseLanguage?> GetByIdAsync(Guid id);
    Task<IEnumerable<CourseLanguage>> GetAllAsync();
    Task AddAsync(CourseLanguage language);
    Task UpdateAsync(CourseLanguage language);
    Task DeleteAsync(Guid id);
}