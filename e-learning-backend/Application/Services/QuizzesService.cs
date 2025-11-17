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
    private readonly IAnswerRepository _answerRepository;

    public QuizzesService(IQuizRepository quizRepository, IQuestionRepository questionRepository,
        IQuestionCategoryRepository questionCategoryRepository, IAnswerRepository answerRepository)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
        _questionCategoryRepository = questionCategoryRepository;
        _answerRepository = answerRepository;
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

    public async Task<IEnumerable<QuizQuestionDTO>> GetUserQuestionsAsync(Guid userId,
        List<Guid>? categoryIds)
    {
        return await _quizRepository.GetUserQuestionsAsync(userId, categoryIds);
    }

    public async Task<QuizQuestionDTO> GetFullQuestionAsync(Guid questionId)
    {
        return await _quizRepository.GetFullQuestionAsync(questionId);
    }

    public async Task<QuestionCategoryDTO> CreateQuestionCategoryAsync(Guid userId,
        string categoryName)
    {
        return await _quizRepository.CreateQuestionCategoryAsync(userId, categoryName);
    }

    public async Task<QuizQuestionDTO> CreateQuestionWithAnswersAsync(Guid userId,
        CreateOrUpdateQuestionDTO orUpdateQuestionDto)
    {
        var question = new Question(
            id: Guid.NewGuid(),
            content: orUpdateQuestionDto.Content
        );

        foreach (var answerDto in orUpdateQuestionDto.Answers)
        {
            var answer = new Answer(
                id: Guid.NewGuid(),
                content: answerDto.Content,
                isCorrect: answerDto.Correct
            );

            question.AddAnswer(answer);
        }

        question.AddAccess(userId, true);

        if (orUpdateQuestionDto.CategoryIds != null && orUpdateQuestionDto.CategoryIds.Count > 0)
        {
            var categories =
                await _questionCategoryRepository.GetByIdsAsync(orUpdateQuestionDto.CategoryIds);

            if (categories.Count() != orUpdateQuestionDto.CategoryIds.Count)
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

    public async Task<QuizQuestionDTO> UpdateQuestionWithAnswersAsync(
        Guid questionId,
        Guid userId,
        CreateOrUpdateQuestionDTO dto)
    {
        var question = await _questionRepository.GetByIdAsync(questionId);

        if (question is null)
        {
            throw new ArgumentException("Question not found");
        }

        if (!question.HasEditAccess(userId))
        {
            throw new UnauthorizedAccessException("You have no access to edit this question");
        }

        question.UpdateContent(dto.Content);

        question.ClearAnswers();

        foreach (var ans in dto.Answers)
        {
            var answer = new Answer(
                id: Guid.NewGuid(),
                content: ans.Content,
                isCorrect: ans.Correct
            );

            await _answerRepository.AddAsync(answer);
            question.AddAnswer(answer);
        }

        question.ClearCategories();

        if (dto.CategoryIds != null && dto.CategoryIds.Any())
        {
            var categories = await _questionCategoryRepository.GetByIdsAsync(dto.CategoryIds);

            if (categories.Count() != dto.CategoryIds.Count)
                throw new ArgumentException("Some categories do not exist.");

            foreach (var cat in categories)
                question.AddCategory(cat);
        }

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
                }).ToList(),
            Categories = question.Categories
                .Select(c => new QuestionCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
        };
    }
    
    public async Task<double> SubmitQuizSolutionAsync(Guid quizId, QuizSolutionDTO solutionDto)
    {
        var quiz = await _quizRepository.GetByIdAsync(quizId);
        
        if (quiz == null)
            throw new ArgumentException("Quiz not found");

        double score = 0;

        foreach (var qSolution in solutionDto.Answers)
        {
            var question = quiz.Questions
                .FirstOrDefault(q => q.Id == qSolution.QuestionId);
            
            if (question == null) continue; // the question does not belong to the quiz
            
            // Poprawne odpowiedzi
            var correctAnswers = question.Answers.Where(a => a.IsCorrect).Select(a => a.Id).ToHashSet();
            var selectedAnswers = qSolution.SelectedAnswerIds.ToHashSet();
            
            if (selectedAnswers.SetEquals(correctAnswers))
            {
                score += 1;
            }
        }
        
        score = (score / quiz.Questions.Count) * 100;
        quiz.Score = score;
        await _quizRepository.SaveChangesAsync();

        return score;
    }
}