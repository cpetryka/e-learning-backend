using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class CourseLanguageRepository : ICourseLanguageRepository
{
    private readonly ApplicationContext _context;

    public CourseLanguageRepository(ApplicationContext context) => _context = context;

    
    public async Task<CourseLanguage?> GetByIdAsync(Guid id)
        => await _context.CourseLanguages
            .SingleOrDefaultAsync(l => l.Id == id);

    
    public async Task<IEnumerable<CourseLanguage>> GetAllAsync()
        => await _context.CourseLanguages
            .ToListAsync();

    
    public async Task AddAsync(CourseLanguage language)
    {
        await _context.CourseLanguages.AddAsync(language);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(CourseLanguage language)
    {
        _context.CourseLanguages.Update(language);
        await _context.SaveChangesAsync();
    }

    
    public async Task DeleteAsync(Guid id)
    {
        var language = await _context.CourseLanguages.FindAsync(id);
        if (language != null)
        {
            _context.CourseLanguages.Remove(language);
            await _context.SaveChangesAsync();
        }
    }
}