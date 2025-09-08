using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class CourseLevelRepository : ICourseLevelRepository
{
    private readonly ApplicationContext _context;

    public CourseLevelRepository(ApplicationContext context) => _context = context;
    
    public async Task<CourseLevel?> GetByIdAsync(Guid id)
        => await _context.CourseLevels
            .SingleOrDefaultAsync(l => l.Id == id);
    
    public async Task<IEnumerable<CourseLevel>> GetAllAsync()
        => await _context.CourseLevels
            .ToListAsync();
    
    public async Task AddAsync(CourseLevel level)
    {
        await _context.CourseLevels.AddAsync(level);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(CourseLevel level)
    {
        _context.CourseLevels.Update(level);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var level = await _context.CourseLevels.FindAsync(id);
        if (level != null)
        {
            _context.CourseLevels.Remove(level);
            await _context.SaveChangesAsync();
        }
    }
}