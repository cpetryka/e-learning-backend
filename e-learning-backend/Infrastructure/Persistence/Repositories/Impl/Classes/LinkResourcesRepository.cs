using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class LinkResourcesRepository : ILinkResourcesRepository
{
    private readonly ApplicationContext _context;

    public LinkResourcesRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<LinkResource?> GetByIdAsync(Guid id)
    {
        return await _context.LinkResources
            .Include(lr => lr.Class)
            .FirstOrDefaultAsync(lr => lr.Id == id);
    }
    
    public async Task AddAsync(LinkResource linkResource)
    {
        await _context.LinkResources.AddAsync(linkResource);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var linkResource = await _context.LinkResources.FindAsync(id);
        
        if (linkResource != null)
        {
            _context.LinkResources.Remove(linkResource);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(LinkResource linkResource)
    {
        _context.LinkResources.Update(linkResource);
        await _context.SaveChangesAsync();
    }
}