using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;

namespace e_learning_backend.Application.Services;

public class QuizzesService : IQuizzesService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    
    public QuizzesService(IQuizRepository quizRepository, IQuestionRepository questionRepository,
        IQuestionCategoryRepository questionCategoryRepository)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
        _questionCategoryRepository = questionCategoryRepository;
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
    
    public async Task<IEnumerable<QuestionCategoryDTO>> GetUserQuestionCategoriesAsync(Guid userId)
    {
        return await _quizRepository.GetUserQuestionCategoriesAsync(userId);
    }
    
    public async Task<IEnumerable<QuizQuestionDTO>> GetUserQuestionsAsync(Guid userId, List<Guid>? categoryIds)
    {
        return await _quizRepository.GetUserQuestionsAsync(userId, categoryIds);
    }
    
    public async Task<QuizQuestionDTO> GetFullQuestionAsync(Guid questionId)
    {
        return await _quizRepository.GetFullQuestionAsync(questionId);
    }
    
    public async Task<QuestionCategoryDTO> CreateQuestionCategoryAsync(Guid userId, string categoryName)
    {
        return await _quizRepository.CreateQuestionCategoryAsync(userId, categoryName);
    }
    
    public async Task<QuizQuestionDTO> CreateQuestionWithAnswersAsync(Guid userId,
        CreateQuestionDTO questionDto)
    {
        var question = new Question(
            id: Guid.NewGuid(),
            content: questionDto.Content
        );

        foreach (var answerDto in questionDto.Answers)
        {
            var answer = new Answer(
                id: Guid.NewGuid(),
                content: answerDto.Content,
                isCorrect: answerDto.Correct
            );

            question.AddAnswer(answer);
        }

        question.AddAccess(userId, true);

        if (questionDto.CategoryIds != null && questionDto.CategoryIds.Count > 0)
        {
            var categories = await _questionCategoryRepository.GetByIdsAsync(questionDto.CategoryIds);

            if (categories.Count() != questionDto.CategoryIds.Count)
                throw new ArgumentException("Some categories do not exist.");

            foreach (var category in categories)
            {
                question.AddCategory(category);
            }
        }

        await _questionRepository.AddAsync(question);
        await _questionRepository.SaveChangesAsync();

        return new QuizQuestionDTO
        {
            Id = question.Id,
            Content = question.Content,
            Answers = question.Answers
                .Select(a => new AnswerDTO
                {
                    Id = a.Id,
                    QuestionId = question.Id,
                    Content = a.Content,
                    Correct = a.IsCorrect
                })
                .ToList(),
            Categories = question.Categories
                .Select(c => new QuestionCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList()
        };
    }
}