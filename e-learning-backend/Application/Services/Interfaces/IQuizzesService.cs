using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Application.Services.Interfaces;

public interface IQuizzesService
{
    Task<IEnumerable<QuizBriefDTO>> GetQuizzesAsync(
        Guid? studentId,
        Guid? courseId,
        string? searchQuery);

    Task<QuizDTO> GetQuizDetailsAsync(Guid quizId);
    Task<IEnumerable<QuizQuestionDTO>> GetQuizQuestionsAsync(Guid quizId);
}