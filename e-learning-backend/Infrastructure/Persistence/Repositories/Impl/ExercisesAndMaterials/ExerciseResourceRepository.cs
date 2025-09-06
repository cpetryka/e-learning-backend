using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ExerciseResourceRepository : IExerciseResourceRepository
{
    private readonly ApplicationContext _context;

    public ExerciseResourceRepository(ApplicationContext context)
        => _context = context;

   
    public async Task<ExerciseResource?> GetByIdsAsync(Guid exerciseId, Guid fileId)
        => await _context.ExerciseResources
            .Include(er => er.Exercise)
            .Include(er => er.File)
            .SingleOrDefaultAsync(er => er.ExerciseId == exerciseId && er.FileId == fileId);

   
    public async Task<IEnumerable<ExerciseResource>> GetAllAsync()
        => await _context.ExerciseResources
            .Include(er => er.Exercise)
            .Include(er => er.File)
            .ToListAsync();

   
    public async Task AddAsync(ExerciseResource resource)
    {
        await _context.ExerciseResources.AddAsync(resource);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(ExerciseResource resource)
    {
        _context.ExerciseResources.Update(resource);
        await _context.SaveChangesAsync();
    }

    
    public async Task DeleteAsync(Guid exerciseId, Guid fileId)
    {
        var resource = await _context.ExerciseResources
            .SingleOrDefaultAsync(er => er.ExerciseId == exerciseId && er.FileId == fileId);

        if (resource != null)
        {
            _context.ExerciseResources.Remove(resource);
            await _context.SaveChangesAsync();
        }
    }
}