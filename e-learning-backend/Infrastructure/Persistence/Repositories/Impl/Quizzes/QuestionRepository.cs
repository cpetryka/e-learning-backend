using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationContext _context;

    public QuestionRepository(ApplicationContext context)
        => _context = context;

    public async Task<Question?> GetByIdAsync(Guid id)
        => await _context.Questions
            .Include(q => q.Categories)
            .Include(q => q.Answers)
            .Include(q => q.Accesses)
            .Include(q => q.Quizzes)
            .SingleOrDefaultAsync(q => q.Id == id);

    public async Task<IEnumerable<Question>> GetAllAsync()
        => await _context.Questions
            .Include(q => q.Categories)
            .Include(q => q.Answers)
            .Include(q => q.Accesses)
            .Include(q => q.Quizzes)
            .ToListAsync();

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question != null)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Question>> GetByCategoryIdAsync(Guid categoryId)
        => await _context.Questions
            .Where(q => q.Categories.Any(c => c.Id == categoryId))
            .Include(q => q.Categories)
            .Include(q => q.Answers)
            .ToListAsync();

    public async Task<IEnumerable<Question>> GetByQuizIdAsync(Guid quizId)
        => await _context.Questions
            .Where(q => q.Quizzes.Any(qz => qz.Id == quizId))
            .Include(q => q.Quizzes)
            .Include(q => q.Answers)
            .ToListAsync();
}