using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IQuizRepository
{
    Task<Quiz?> GetByIdAsync(Guid id);
    Task<IEnumerable<Quiz>> GetAllAsync();
    Task AddAsync(Quiz quiz);
    Task UpdateAsync(Quiz quiz);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Quiz>> GetByClassIdAsync(Guid classId);
}