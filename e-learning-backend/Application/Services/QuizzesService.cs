using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;

namespace e_learning_backend.Application.Services;

public class QuizzesService : IQuizzesService
{
    private readonly IQuizRepository _quizRepository;
    
    public QuizzesService(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<IEnumerable<QuizBriefDTO>> GetQuizzesAsync(
        Guid? studentId,
        Guid? courseId,
        string? searchQuery)
    {
        return await _quizRepository.GetQuizzesAsync(studentId, courseId, searchQuery);
    }
    
    public async Task<QuizDTO> GetQuizDetailsAsync(Guid quizId)
    {
        return await _quizRepository.GetQuizDetailsAsync(quizId);
    }
    
    public async Task<IEnumerable<QuizQuestionDTO>> GetQuizQuestionsAsync(Guid quizId)
    {
        return await _quizRepository.GetQuizQuestionsAsync(quizId);
    }
}