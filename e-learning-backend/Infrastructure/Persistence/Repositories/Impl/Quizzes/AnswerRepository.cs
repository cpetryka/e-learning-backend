using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class AnswerRepository : IAnswerRepository
{
    private readonly ApplicationContext _context;

    public AnswerRepository(ApplicationContext context)
        => _context = context;

    public async Task<Answer?> GetByIdAsync(Guid id)
        => await _context.Answers
            .Include(a => a.Questions)
            .SingleOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<Answer>> GetAllAsync()
        => await _context.Answers
            .Include(a => a.Questions)
            .ToListAsync();

    public async Task AddAsync(Answer answer)
    {
        await _context.Answers.AddAsync(answer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Answer answer)
    {
        _context.Answers.Update(answer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer != null)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Answer>> GetByQuestionIdAsync(Guid questionId)
        => await _context.Answers
            .Where(a => a.Questions.Any(q => q.Id == questionId))
            .Include(a => a.Questions)
            .ToListAsync();
}