using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class CourseVariantRepository : ICourseVariantRepository
{
    private readonly ApplicationContext _context;

    public CourseVariantRepository(ApplicationContext context) => _context = context;


    public async Task<CourseVariant?> GetByIdAsync(Guid id)
        => await _context.CourseVariants
            .Include(v => v.Level)
            .Include(v => v.Language)
            .SingleOrDefaultAsync(v => v.Id == id);


    public async Task<IEnumerable<CourseVariant>> GetAllAsync()
        => await _context.CourseVariants
            .Include(v => v.Level)
            .Include(v => v.Language)
            .ToListAsync();


    public async Task AddAsync(CourseVariant variant)
    {
        await _context.CourseVariants.AddAsync(variant);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(CourseVariant variant)
    {
        _context.CourseVariants.Update(variant);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id)
    {
        var variant = await _context.CourseVariants.FindAsync(id);
        if (variant != null)
        {
            _context.CourseVariants.Remove(variant);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<CourseVariant?> GetByAttributesAsync(Guid courseId, Guid levelId, Guid languageId)
    {
        return await _context.CourseVariants
            .Include(v => v.Level)
            .Include(v => v.Language)
            .SingleOrDefaultAsync(v =>
                v.CourseId == courseId &&
                v.Level.Id == levelId &&
                v.Language.Id == languageId);
    }
}