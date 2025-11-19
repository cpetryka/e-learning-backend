using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Application.Services.Interfaces;

public interface IQuizzesService
{
    Task<IEnumerable<QuizBriefDTO>> GetQuizzesAsync(
        Guid? studentId,
        Guid? courseId,
        Guid? classId,
        string? searchQuery);

    Task<QuizDTO> GetQuizDetailsAsync(Guid quizId);
    Task<IEnumerable<QuizQuestionDTO>> GetQuizQuestionsAsync(Guid quizId);
    Task<IEnumerable<QuestionCategoryDTO>> GetUserQuestionCategoriesAsync(Guid userId);
    Task<IEnumerable<QuizQuestionDTO>> GetUserQuestionsAsync(Guid userId, List<Guid>? categoryIds);
    Task<QuizQuestionDTO> GetFullQuestionAsync(Guid questionId);
    Task<QuestionCategoryDTO> CreateQuestionCategoryAsync(Guid userId, string categoryName);

    Task<QuizQuestionDTO> CreateQuestionWithAnswersAsync(Guid userId,
        CreateOrUpdateQuestionDTO orUpdateQuestionDto);

    Task<QuizQuestionDTO> UpdateQuestionWithAnswersAsync(
        Guid questionId,
        Guid userId,
        CreateOrUpdateQuestionDTO dto);

    Task<double> SubmitQuizSolutionAsync(Guid quizId, QuizSolutionDTO solutionDto);
    Task<Guid> CreateQuizAsync(Guid userId, AddQuizDTO addQuizDto);
}