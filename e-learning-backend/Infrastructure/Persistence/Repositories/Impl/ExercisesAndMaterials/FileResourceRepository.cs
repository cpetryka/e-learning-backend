using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class FileResourceRepository : IFileResourceRepository
{
    private readonly ApplicationContext _context;

    public FileResourceRepository(ApplicationContext context)
        => _context = context;


    public async Task<FileResource?> GetByIdAsync(Guid id)
        => await _context.FileResources
            .Include(f => f.User)
            .Include(f => f.Tags)
            .Include(f => f.ExerciseResources)
            .SingleOrDefaultAsync(f => f.Id == id);


    public async Task<IEnumerable<FileResource>> GetAllAsync()
        => await _context.FileResources
            .Include(f => f.User)
            .Include(f => f.Tags)
            .Include(f => f.ExerciseResources)
            .ToListAsync();
    
    
    public async Task<IEnumerable<FileResource>> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
        => await _context.FileResources
            .AsNoTracking()
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.AddedAt)
            .ToListAsync(ct);
    

    public async Task AddAsync(FileResource file)
    {
        await _context.FileResources.AddAsync(file);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(FileResource file)
    {
        _context.FileResources.Update(file);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id)
    {
        var file = await _context.FileResources.FindAsync(id);
        if (file != null)
        {
            _context.FileResources.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}