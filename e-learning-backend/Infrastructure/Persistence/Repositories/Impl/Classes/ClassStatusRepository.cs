using e_learning_backend.Domain.Classes.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ClassStatusRepository : IClassStatusRepository
{
    private readonly ApplicationContext _context;

    public ClassStatusRepository(ApplicationContext context)
        => _context = context;

    public async Task<ClassStatus?> GetByIdAsync(Guid id)
        => await _context.ClassStatuses
            .SingleOrDefaultAsync(s => s.Id == id);

    public async Task<IEnumerable<ClassStatus>> GetAllAsync()
        => await _context.ClassStatuses.ToListAsync();

    public async Task AddAsync(ClassStatus status)
    {
        await _context.ClassStatuses.AddAsync(status);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ClassStatus status)
    {
        _context.ClassStatuses.Update(status);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var status = await _context.ClassStatuses.FindAsync(id);
        if (status != null)
        {
            _context.ClassStatuses.Remove(status);
            await _context.SaveChangesAsync();
        }
    }
}