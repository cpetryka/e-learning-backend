using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IQuestionCategoryRepository
{
    Task<QuestionCategory?> GetByIdAsync(Guid id);
    Task<IEnumerable<QuestionCategory>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<IEnumerable<QuestionCategory>> GetAllAsync();
    Task AddAsync(QuestionCategory category);
    Task UpdateAsync(QuestionCategory category);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<QuestionCategory>> GetByTeacherIdAsync(Guid teacherId);
}