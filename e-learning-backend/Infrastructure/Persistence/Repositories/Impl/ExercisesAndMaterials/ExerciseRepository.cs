using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationContext _context;

    public ExerciseRepository(ApplicationContext context) => _context = context;

    
    public async Task<Exercise?> GetByIdAsync(Guid id)
        => await _context.Exercises
            .Include(e => e.Class)
            .Include(e => e.ExerciseResources)
            .SingleOrDefaultAsync(e => e.Id == id);

    
    public async Task<IEnumerable<Exercise>> GetAllAsync()
        => await _context.Exercises
            .Include(e => e.Class)
            .Include(e => e.ExerciseResources)
            .ToListAsync();

   
    public async Task AddAsync(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();
    }

    
    public async Task UpdateAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }

    
    public async Task DeleteAsync(Guid id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
