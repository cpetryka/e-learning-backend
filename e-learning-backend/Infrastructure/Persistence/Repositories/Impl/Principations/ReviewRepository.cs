using e_learning_backend.Domain.Participations;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationContext _context;

    public ReviewRepository(ApplicationContext context)
        => _context = context;

    public async Task<Review?> GetByIdAsync(Guid id)
        => await _context.Reviews
            .Include(r => r.Participation)
            .SingleOrDefaultAsync(r => r.Id == id);

    public async Task<IEnumerable<Review>> GetAllAsync()
        => await _context.Reviews
            .Include(r => r.Participation)
            .ToListAsync();

    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Review?> GetByParticipationIdAsync(Guid userId, Guid courseId)
        => await _context.Reviews
            .Include(r => r.Participation)
            .Where(r => r.Participation.UserId == userId && r.Participation.CourseId == courseId)
            .SingleOrDefaultAsync();
}