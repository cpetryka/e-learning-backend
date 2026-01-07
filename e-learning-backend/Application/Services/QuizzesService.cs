using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

namespace e_learning_backend.Application.Services;

public class QuizzesService : IQuizzesService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IAnswerRepository _answerRepository;
    private readonly IClassRepository _classRepository;

    public QuizzesService(IQuizRepository quizRepository, IQuestionRepository questionRepository,
        IQuestionCategoryRepository questionCategoryRepository, IAnswerRepository answerRepository,
        IClassRepository classRepository)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
        _questionCategoryRepository = questionCategoryRepository;
        _answerRepository = answerRepository;
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<QuizBriefDTO>> GetQuizzesAsync(
        Guid studentId,
        Guid? courseId,
        Guid? classId,
        string? searchQuery)
    {
        return await _quizRepository.GetQuizzesAsync(studentId, courseId, classId, searchQuery);
    }

    public async Task<IEnumerable<QuizBriefDTO>> GetTeacherQuizzesAsync(
        Guid teacherId,
        Guid? courseId,
        Guid? classId,
        string? searchQuery)
    {
        return await _quizRepository.GetStudentQuizzesAsync(teacherId, courseId, classId, searchQuery);
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

            var correctAnswers =
                question.Answers.Where(a => a.IsCorrect).Select(a => a.Id).ToHashSet();
            var selectedAnswers = qSolution.SelectedAnswerIds.ToHashSet();

            if (selectedAnswers.SetEquals(correctAnswers))
            {
                score += 1;
            }
        }

        if (quiz.Questions.Count == 0)
        {
            score = 0;
        }
        else
        {
            score = (score / quiz.Questions.Count) * 100;
        }

        quiz.Score = score;
        await _quizRepository.SaveChangesAsync();

        return score;
    }

    public async Task<Guid> CreateQuizAsync(Guid userId, AddQuizDTO addQuizDto)
    {
        if (addQuizDto == null)
            throw new ArgumentNullException(nameof(addQuizDto));

        var singleClass = await _classRepository.GetByIdAsync(addQuizDto.ClassId);
        if (singleClass == null)
        {
            throw new ArgumentException("Class not found.");
        }

        var quiz = new Quiz(
            id: Guid.NewGuid(),
            title: addQuizDto.Name,
            multipleChoice: addQuizDto.IsMultipleChoice,
            singleClass: singleClass
        );

        if (addQuizDto.QuestionIds != null && addQuizDto.QuestionIds.Any())
        {
            foreach (var qid in addQuizDto.QuestionIds)
            {
                var question = await _questionRepository.GetByIdAsync(qid);
                if (question == null)
                    throw new ArgumentException($"Question with id {qid} not found.");

                quiz.AddQuestion(question);
            }
        }

        await _quizRepository.AddAsync(quiz);
        await _quizRepository.SaveChangesAsync();

        return quiz.Id;
    }

    // public async Task<Guid> CopyQuizAsync(Guid userId, Guid quizId, Guid classId)
    // {
    //     // Ensure source quiz exists
    //     var sourceQuiz = await _quizRepository.GetByIdAsync(quizId);
    //     if (sourceQuiz == null)
    //     {
    //         throw new ArgumentException("Quiz not found.");
    //     }
    //
    //     // Ensure target class exists
    //     var targetClass = await _classRepository.GetByIdAsync(classId);
    //     if (targetClass == null)
    //     {
    //         throw new ArgumentException("Class not found.");
    //     }
    //
    //     // Delegate the actual copy to the repository which will create & persist the new quiz
    //     var newQuizId = await _quizRepository.CopyQuizAsync(quizId, classId);
    //     return newQuizId;
    // }

    public async Task<Guid> CopyQuizAsync(Guid userId, Guid quizId, Guid classId)
    {
        // Ensure source quiz exists
        var sourceQuiz = await _quizRepository.GetByIdAsync(quizId);
        if (sourceQuiz == null)
        {
            throw new ArgumentException("Quiz not found.");
        }

        // Ensure target class exists
        var targetClass = await _classRepository.GetByIdAsync(classId);
        if (targetClass == null)
        {
            throw new ArgumentException("Class not found.");
        }

        // Construct new Quiz and associate existing questions
        var newQuiz = new Quiz(Guid.NewGuid(), sourceQuiz.Title, sourceQuiz.MultipleChoice,
            targetClass);
        foreach (var question in sourceQuiz.Questions)
        {
            newQuiz.AddQuestion(question);
        }

        // Persist
        await _quizRepository.AddAsync(newQuiz);
        await _quizRepository.SaveChangesAsync();

        return newQuiz.Id;
    }

    public async Task<bool> EditQuizAsync(Guid userId, Guid quizId, string? name,
        IEnumerable<Guid>? questionIds = null)
    {
        var quiz = await _quizRepository.GetByIdAsync(quizId);
        if (quiz == null)
        {
            throw new ArgumentException("Quiz not found.");
        }

        // Only course teacher may edit
        /*var teacherId = quiz.Class?.Participation?.Course?.TeacherId;
        if (teacherId is null || teacherId != userId)
        {
            return false;
        }*/

        // Update name if provided (null means leave as is)
        if (name != null)
        {
            quiz.SetTitle(name);
        }

        // Synchronize questions
        var existingQuestions = quiz.Questions.ToList();

        if (questionIds == null)
        {
            // Remove all questions
            foreach (var q in existingQuestions)
            {
                quiz.RemoveQuestion(q);
            }
        }
        else
        {
            var requestedIds = new HashSet<Guid>(questionIds);

            // Remove questions that are not requested
            var toRemove = existingQuestions.Where(q => !requestedIds.Contains(q.Id)).ToList();
            foreach (var q in toRemove)
            {
                quiz.RemoveQuestion(q);
            }

            // Determine which ids need to be added
            var remainingIds = quiz.Questions.Select(q => q.Id).ToHashSet();
            var toAddIds = requestedIds.Except(remainingIds);

            foreach (var qid in toAddIds)
            {
                var question = await _questionRepository.GetByIdAsync(qid);
                if (question == null)
                {
                    throw new ArgumentException($"Question with id {qid} not found.");
                }

                quiz.AddQuestion(question);
            }
        }

        await _quizRepository.UpdateAsync(quiz);
        return true;
    }
}