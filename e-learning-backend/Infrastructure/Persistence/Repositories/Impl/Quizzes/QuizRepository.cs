using e_learning_backend.Domain.Quizzes;
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
            .Include(q => q.Questions)
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
}