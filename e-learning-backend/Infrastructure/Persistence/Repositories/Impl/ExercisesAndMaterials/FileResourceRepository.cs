using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class FileResourceRepo3sitory : IFileResourceRepository
{
    private readonly ApplicationContext _context;

    public FileResourceRepo3sitory(ApplicationContext context)
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


    public async Task<bool> DeleteFileAsync(Guid id, CancellationToken ct = default)
    {
        var file = await _context.FileResources.FindAsync(new object?[] { id }, ct);
        
        if (file is null)
            return false;
        
        _context.FileResources.Remove(file);
        await _context.SaveChangesAsync(ct);
        
        return true;
    }


    public async Task<IEnumerable<FileResource>> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
        => await _context.FileResources
            .AsNoTracking()
            .Where(f => f.UserId == userId)
            .Include(f => f.Tags)
            .Include(f=>f.Classes)
                .ThenInclude(f=>f.Participation)
                .ThenInclude(f=>f.User)
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
    
}