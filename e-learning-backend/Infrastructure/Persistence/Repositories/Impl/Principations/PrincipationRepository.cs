using e_learning_backend.Domain.Participations;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ParticipationRepository : IParticipationRepository
{
    private readonly ApplicationContext _context;

    public ParticipationRepository(ApplicationContext context)
        => _context = context;

    public async Task<Participation?> GetByIdAsync(Guid userId, Guid courseId)
        => await _context.Participations
            .Include(p => p.User)
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
                    .ThenInclude(co => co.Teacher)
            .Include(p => p.Review)
            .Include(p => p.Classes)
            .SingleOrDefaultAsync(p => p.UserId == userId && p.CourseVariant.CourseId == courseId);

    public async Task<IEnumerable<Participation>> GetByIdsAsync(Guid userId, IEnumerable<Guid> courseIds)
    {
        return await _context.Participations
            .Include(p => p.User)
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
            .Include(p => p.Review)
            .Include(p => p.Classes)
            .Where(p => p.UserId == userId && courseIds.Contains(p.CourseVariant.CourseId))
            .ToListAsync();
    }
        
    public async Task<IEnumerable<Participation>> GetAllAsync()
        => await _context.Participations
            .Include(p => p.User)
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
            .Include(p => p.Review)
            .Include(p => p.Classes)
            .ToListAsync();

    public async Task AddAsync(Participation participation)
    {
        await _context.Participations.AddAsync(participation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Participation participation)
    {
        _context.Participations.Update(participation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId, Guid courseId)
    {
        var participation = await _context.Participations
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
            .FirstOrDefaultAsync(p => p.UserId == userId && p.CourseVariant.CourseId == courseId);

        if (participation != null)
        {
            _context.Participations.Remove(participation);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Participation>> GetByUserIdAsync(Guid userId)
        => await _context.Participations
            .Where(p => p.UserId == userId)
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
            .Include(p => p.Review)
            .Include(p => p.Classes)
            .ToListAsync();
    
    public async Task<IEnumerable<ParticipationBriefDTO>> GetBriefByUserIdAsync(Guid studentId)
        =>
            await _context.Participations
                .Include(p => p.CourseVariant)
                    .ThenInclude(cv => cv.Course)
                .Where(p => p.UserId == studentId)
                .Select(p => new ParticipationBriefDTO
                {
                    CourseId = p.CourseVariant.CourseId,
                    UserId = p.UserId,
                    CourseName = p.CourseVariant.Course.Name
                })
                .Distinct()
                .ToListAsync();
    
    public async Task<IEnumerable<Participation>> GetByCourseIdAsync(Guid courseId)
        => await _context.Participations
            .Include(p => p.CourseVariant)
                .ThenInclude(cv => cv.Course)
            .Where(p => p.CourseVariant.CourseId == courseId)
            .Include(p => p.User)
            .Include(p => p.Review)
            .Include(p => p.Classes)
            .ToListAsync();
}