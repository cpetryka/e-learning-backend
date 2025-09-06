using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class CourseCategoryRepository : ICourseCategoryRepository
{
    private readonly ApplicationContext _context;

    public CourseCategoryRepository(ApplicationContext context) => _context = context;

   
    public async Task<CourseCategory?> GetByIdAsync(Guid id)
        => await _context.CourseCategories
            .SingleOrDefaultAsync(c => c.Id == id);

    
    public async Task<IEnumerable<CourseCategory>> GetAllAsync()
        => await _context.CourseCategories
            .ToListAsync();

    
    public async Task AddAsync(CourseCategory category)
    {
        await _context.CourseCategories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(CourseCategory category)
    {
        _context.CourseCategories.Update(category);
        await _context.SaveChangesAsync();
    }

    
    public async Task DeleteAsync(Guid id)
    {
        var category = await _context.CourseCategories.FindAsync(id);
        if (category != null)
        {
            _context.CourseCategories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}