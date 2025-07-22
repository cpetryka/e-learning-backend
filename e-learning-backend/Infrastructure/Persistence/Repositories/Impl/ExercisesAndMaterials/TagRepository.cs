using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class TagRepository : ITagRepository
{
    private readonly ApplicationContext _context;

    public TagRepository(ApplicationContext context)
        => _context = context;

    
    public async Task<Tag?> GetByIdAsync(Guid id)
        => await _context.Tags
            .Include(t => t.Teacher)
            .Include(t => t.Files)
            .SingleOrDefaultAsync(t => t.Id == id);

    
    public async Task<IEnumerable<Tag>> GetAllAsync()
        => await _context.Tags
            .Include(t => t.Teacher)
            .Include(t => t.Files)
            .ToListAsync();

   
    public async Task AddAsync(Tag tag)
    {
        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
    }

   
    public async Task DeleteAsync(Guid id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }
    }

    
    public async Task<IEnumerable<Tag>> GetByTeacherIdAsync(Guid teacherId)
        => await _context.Tags
            .Where(t => t.TeacherId == teacherId)
            .Include(t => t.Files)
            .ToListAsync();
}