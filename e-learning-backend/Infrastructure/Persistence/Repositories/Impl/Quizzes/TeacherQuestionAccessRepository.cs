using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class TeacherQuestionAccessRepository : ITeacherQuestionAccessRepository
{
    private readonly ApplicationContext _context;

    public TeacherQuestionAccessRepository(ApplicationContext context)
        => _context = context;

    public async Task<TeacherQuestionAccess?> GetByIdAsync(Guid teacherId, Guid questionId)
        => await _context.TeacherQuestionAccesses
            .Include(a => a.Teacher)
            .Include(a => a.Question)
            .SingleOrDefaultAsync(a => a.TeacherId == teacherId && a.QuestionId == questionId);

    public async Task<IEnumerable<TeacherQuestionAccess>> GetAllAsync()
        => await _context.TeacherQuestionAccesses
            .Include(a => a.Teacher)
            .Include(a => a.Question)
            .ToListAsync();

    public async Task AddAsync(TeacherQuestionAccess access)
    {
        await _context.TeacherQuestionAccesses.AddAsync(access);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TeacherQuestionAccess access)
    {
        _context.TeacherQuestionAccesses.Update(access);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid teacherId, Guid questionId)
    {
        var access = await _context.TeacherQuestionAccesses
            .SingleOrDefaultAsync(a => a.TeacherId == teacherId && a.QuestionId == questionId);

        if (access != null)
        {
            _context.TeacherQuestionAccesses.Remove(access);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TeacherQuestionAccess>> GetByTeacherIdAsync(Guid teacherId)
        => await _context.TeacherQuestionAccesses
            .Where(a => a.TeacherId == teacherId)
            .Include(a => a.Question)
            .ToListAsync();

    public async Task<IEnumerable<TeacherQuestionAccess>> GetByQuestionIdAsync(Guid questionId)
        => await _context.TeacherQuestionAccesses
            .Where(a => a.QuestionId == questionId)
            .Include(a => a.Teacher)
            .ToListAsync();
}
