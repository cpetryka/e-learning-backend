using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IQuizRepository
{
    Task<Quiz?> GetByIdAsync(Guid id);
    Task<IEnumerable<Quiz>> GetAllAsync();
    Task AddAsync(Quiz quiz);
    Task UpdateAsync(Quiz quiz);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Quiz>> GetByClassIdAsync(Guid classId);

    Task<IEnumerable<QuizBriefDTO>> GetQuizzesAsync(
        Guid? studentId,
        Guid? courseId,
        string? searchQuery);
    
    Task<QuizDTO> GetQuizDetailsAsync(Guid quizId);
    
    Task<IEnumerable<QuizQuestionDTO>> GetQuizQuestionsAsync(Guid quizId);
}