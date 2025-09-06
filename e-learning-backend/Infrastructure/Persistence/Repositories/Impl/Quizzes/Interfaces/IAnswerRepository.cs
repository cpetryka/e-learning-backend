using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IAnswerRepository
{
    Task<Answer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Answer>> GetAllAsync();
    Task AddAsync(Answer answer);
    Task UpdateAsync(Answer answer);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Answer>> GetByQuestionIdAsync(Guid questionId);
}