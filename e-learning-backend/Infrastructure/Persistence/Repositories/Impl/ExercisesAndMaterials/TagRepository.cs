using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class TagRepository : ITagRepository
{
    private class UserFileTagRow
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; } = default!;
        public Guid OwnerId { get; set; }
    }
    
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
    
    public async  Task<IEnumerable<GetFileDTO.TagDTO>> GetByUserId(Guid userId, CancellationToken ct = default)
    {
        var rows = await _context.Database
            .SqlQueryRaw<UserFileTagRow>(
                """
                SELECT
                    "TagId",
                    "TagName",
                    "OwnerId"
                FROM get_user_file_tags({0})
                """,
                userId
            )
            .ToListAsync(ct);
        
        var result = rows
            .Select(r => new GetFileDTO.TagDTO()
            {
                Id = r.TagId,
                Name = r.TagName,
                OwnerId = r.OwnerId
            })
            .ToList();

        return result;
    }


}

