using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ClassRepository : IClassRepository
{
    private readonly ApplicationContext _context;

    public ClassRepository(ApplicationContext context) => _context = context;


    public async Task<Class?> GetByIdAsync(Guid id)
        => await _context.Classes
            .Include(c => c.Exercises)
            .Include(c => c.Quizzes)
            .Include(c => c.Files)
            .SingleOrDefaultAsync(c => c.Id == id);
    
    public async Task<IEnumerable<Class>> GetAllAsync()
        => await _context.Classes
            .Include(c => c.Exercises)
            .Include(c => c.Quizzes)
            .Include(c => c.Files)
            .ToListAsync();
    
    public async Task AddAsync(Class cls)
    {
        await _context.Classes.AddAsync(cls);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Class cls)
    {
        _context.Classes.Update(cls);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var cls = await _context.Classes.FindAsync(id);
        if (cls != null)
        {
            _context.Classes.Remove(cls);
            await _context.SaveChangesAsync();
        }
    }
    
public async Task<IEnumerable<Class>> GetByUserAndCoursesInDateRangeAsync(
    Guid studentId,
    IEnumerable<Guid> courseIds,
    DateTime from,
    DateTime to)
{
    var classes = await _context.Classes
        .Include(c => c.Status)
        .Include(c => c.Exercises)
        .Include(c => c.Quizzes)
        .Include(c => c.Files)
        .Include(c => c.Links)
        .Include(c => c.Participation)
            .ThenInclude(p => p.Course)
        .AsSplitQuery()
        .Where(c => courseIds.Contains(c.CourseId) &&
                    _context.Participations.Any(p => p.UserId == studentId && p.CourseId == c.CourseId) &&
                    c.StartTime >= from &&
                    c.StartTime <= to)
        .ToListAsync();
    
    return classes;
}


}