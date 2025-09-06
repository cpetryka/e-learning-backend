using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IQuestionRepository
{
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetAllAsync();
    Task AddAsync(Question question);
    Task UpdateAsync(Question question);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Question>> GetByCategoryIdAsync(Guid categoryId);
    Task<IEnumerable<Question>> GetByQuizIdAsync(Guid quizId);
}