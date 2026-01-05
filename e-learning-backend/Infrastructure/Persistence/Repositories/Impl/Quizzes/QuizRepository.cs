using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class QuizRepository : IQuizRepository
{
    private readonly ApplicationContext _context;

    public QuizRepository(ApplicationContext context)
        => _context = context;

    public async Task<Quiz?> GetByIdAsync(Guid id)
        => await _context.Quizzes
            .Include(q => q.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .ThenInclude(c => c.Teacher)
            .Include(q => q.Questions)
            .ThenInclude(question => question.Answers)
            .SingleOrDefaultAsync(q => q.Id == id);

    public async Task<IEnumerable<Quiz>> GetAllAsync()
        => await _context.Quizzes
            .Include(q => q.Class)
            .Include(q => q.Questions)
            .ToListAsync();

    public async Task AddAsync(Quiz quiz)
    {
        await _context.Quizzes.AddAsync(quiz);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Quiz quiz)
    {
        _context.Quizzes.Update(quiz);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);
        if (quiz != null)
        {
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Quiz>> GetByClassIdAsync(Guid classId)
        => await _context.Quizzes
            .Where(q => q.ClassId == classId)
            .Include(q => q.Questions)
            .ToListAsync();
    
    public async Task<IEnumerable<QuizBriefDTO>> GetQuizzesAsync(
        Guid studentId,
        Guid? courseId,
        Guid? classId,
        string? searchQuery)
    {
        return await _context.Quizzes
            .Include(q => q.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .Where(q => q.Class.Participation.UserId == studentId)
            .Where(q => !courseId.HasValue || q.Class.Participation.CourseVariant.CourseId == courseId.Value)
            .Where(q => !classId.HasValue || q.Class.Id == classId.Value)
            .Where(q => string.IsNullOrEmpty(searchQuery) || q.Title.ToLower().Contains(searchQuery.ToLower()))
            .Select(q => new QuizBriefDTO
            {
                Id = q.Id,
                Name = q.Title,
                CourseId = q.Class.Participation.CourseVariant.CourseId,
                CourseName = q.Class.Participation.CourseVariant.Course.Name,
                QuestionNumber = q.Questions.Count,
                Completed = q.Score.HasValue
            })
            .ToListAsync();
    }
    
    public async Task<QuizDTO> GetQuizDetailsAsync(Guid quizId)
    {
        return await _context.Quizzes
            .Include(q => q.Questions)
            .Include(q => q.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .Select(q => new QuizDTO
            {
                Id = q.Id,
                Name = q.Title,
                ClassId = q.ClassId,
                CourseId = q.Class.Participation.CourseVariant.CourseId,
                CourseName = q.Class.Participation.CourseVariant.Course.Name,
                TeacherId = q.Class.Participation.CourseVariant.Course.TeacherId,
                StudentId = q.Class.UserId,
                IsMultipleChoice = q.MultipleChoice,
                Score = q.Score,
                MaxScore = q.Questions.Count
            })
            .SingleOrDefaultAsync(q => q.Id == quizId);
    }
    
    public async Task<IEnumerable<QuizQuestionDTO>> GetQuizQuestionsAsync(Guid quizId)
    {
        return await _context.Quizzes
            .Where(q => q.Id == quizId)
            .Include(q => q.Questions)
            .ThenInclude(qq => qq.Categories)
            .Include(q => q.Questions)
            .ThenInclude(qq => qq.Answers)
            .SelectMany(q => q.Questions.Select(qq => new QuizQuestionDTO
            {
                Id = qq.Id,
                Content = qq.Content,
                Categories = qq.Categories
                    .Select(qc => new QuestionCategoryDTO
                    {
                        Id = qc.Id,
                        Name = qc.Name
                    })
                    .ToList(),
                Answers = qq.Answers
                    .Select(a => new AnswerDTO
                    {
                        Id = a.Id,
                        QuestionId = qq.Id,
                        Content = a.Content
                    })
                    .ToList()
            }))
            .ToListAsync();
    }
    
    public async Task<IEnumerable<QuestionCategoryDTO>> GetUserQuestionCategoriesAsync(Guid userId)
    {
        return await _context.QuestionCategories
            .Where(qc => qc.TeacherId == userId)
            .Select(qc => new QuestionCategoryDTO
            {
                Id = qc.Id,
                Name = qc.Name
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<QuizQuestionDTO>> GetUserQuestionsAsync(Guid userId, List<Guid>? categoryIds)
    {
        var query = _context.Questions
            .Include(q => q.Accesses)
            .Where(q => q.Accesses.Any(a => a.TeacherId == userId))
            .AsQueryable();

        if (categoryIds != null && categoryIds.Any())
        {
            query = query.Where(qq => qq.Categories.Any(qc => categoryIds.Contains(qc.Id)));
        }

        return await query
            .Select(qq => new QuizQuestionDTO
            {
                Id = qq.Id,
                Content = qq.Content,
                Categories = qq.Categories
                    .Select(qc => new QuestionCategoryDTO
                    {
                        Id = qc.Id,
                        Name = qc.Name
                    })
                    .ToList()
            })
            .ToListAsync()
            .ContinueWith(t => (IEnumerable<QuizQuestionDTO>)t.Result);
    }

    public async Task<QuizQuestionDTO> GetFullQuestionAsync(Guid questionId)
    {
        return await _context.Questions
            .Include(q => q.Accesses)
            .Where(q => q.Id == questionId)
            .Select(qq => new QuizQuestionDTO
            {
                Id = qq.Id,
                Content = qq.Content,
                Categories = qq.Categories
                    .Select(qc => new QuestionCategoryDTO
                    {
                        Id = qc.Id,
                        Name = qc.Name
                    })
                    .ToList(),
                Answers = qq.Answers
                    .Select(a => new AnswerDTO
                    {
                        Id = a.Id,
                        QuestionId = qq.Id,
                        Content = a.Content,
                        Correct = a.IsCorrect
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<QuestionCategoryDTO> CreateQuestionCategoryAsync(Guid userId, string categoryName)
    {
        var existingCategory = await _context.QuestionCategories
            .FirstOrDefaultAsync(qc => qc.TeacherId == userId && qc.Name == categoryName);
        
        if (existingCategory != null)
        {
            throw new InvalidOperationException($"Question category with name '{categoryName}' already exists.");
        }
        
        var category = new QuestionCategory(Guid.NewGuid(), categoryName, "", userId);

        _context.QuestionCategories.Add(category);
        await _context.SaveChangesAsync();

        return new QuestionCategoryDTO
        {
            Id = category.Id,
            Name = category.Name
        };
    }
    
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}