using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class QuestionCategoryRepository : IQuestionCategoryRepository
{
    private readonly ApplicationContext _context;

    public QuestionCategoryRepository(ApplicationContext context)
        => _context = context;

    public async Task<QuestionCategory?> GetByIdAsync(Guid id)
        => await _context.QuestionCategories
            .Include(c => c.Teacher)
            .Include(c => c.Questions)
            .SingleOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<QuestionCategory>> GetAllAsync()
        => await _context.QuestionCategories
            .Include(c => c.Teacher)
            .Include(c => c.Questions)
            .ToListAsync();

    public async Task AddAsync(QuestionCategory category)
    {
        await _context.QuestionCategories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(QuestionCategory category)
    {
        _context.QuestionCategories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _context.QuestionCategories.FindAsync(id);
        if (category != null)
        {
            _context.QuestionCategories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<QuestionCategory>> GetByTeacherIdAsync(Guid teacherId)
        => await _context.QuestionCategories
            .Where(c => c.TeacherId == teacherId)
            .Include(c => c.Questions)
            .ToListAsync();
}