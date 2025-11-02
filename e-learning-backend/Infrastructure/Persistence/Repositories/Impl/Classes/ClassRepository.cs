using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class ClassRepository : IClassRepository
{
    private readonly ApplicationContext _context;

    public ClassRepository(ApplicationContext context) => _context = context;


    public async Task<Class?> GetByIdAsync(Guid id)
        => await _context.Classes
            .Include(c => c.Exercises)
            .Include(c => c.Quizzes)
            .Include(c => c.Files)
            .Include(c => c.Participation)
                .ThenInclude(p => p.Course)
            .Include(c => c.Links)
            .Include(c => c.Status)
            .SingleOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Class>> GetAllAsync()
        => await _context.Classes
            .Include(c => c.Exercises)
            .Include(c => c.Quizzes)
            .Include(c => c.Files)
            .ToListAsync();

    public async Task AddAsync(Class cls)
    {
        await _context.Classes.AddAsync(cls);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Class cls)
    {
        _context.Classes.Update(cls);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var cls = await _context.Classes.FindAsync(id);
        if (cls != null)
        {
            _context.Classes.Remove(cls);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Class>> GetByUserAndCoursesInDateRangeAsync(
        Guid studentId,
        IEnumerable<Guid> courseIds,
        DateTime from,
        DateTime to)
    {
        var classes = await _context.Classes
            .Include(c => c.Status)
            .Include(c => c.Exercises)
            .Include(c => c.Quizzes)
            .Include(c => c.Files)
            .Include(c => c.Links)
            .Include(c => c.Participation)
            .ThenInclude(p => p.Course)
            .AsSplitQuery()
            .Where(c => courseIds.Contains(c.CourseId) &&
                        _context.Participations.Any(p => p.UserId == studentId && p.CourseId == c.CourseId) &&
                        c.StartTime >= from &&
                        c.StartTime <= to)
            .ToListAsync();

        return classes;
    }

    /// <summary>
    /// Retrieves all upcoming classes for a specific student within the next 14 days (UTC).
    /// </summary>
    /// <param name="userId">The unique identifier of the student.</param>
    /// <returns>
    /// A collection of <see cref="ClassDTO"/> objects representing upcoming classes 
    /// that the specified student is enrolled in. Each item includes:
    /// <list type="bullet">
    ///   <item><description>The class start time (<c>StartTime</c>).</description></item>
    ///   <item><description>The associated course ID (<c>CourseId</c>).</description></item>
    ///   <item><description>The course name (<c>CourseName</c>).</description></item>
    ///   <item><description>The teacher ID responsible for the course (<c>TeacherId</c>).</description></item>
    /// </list>
    /// </returns>
    public async Task<IEnumerable<ClassDTO>> GetUpcomingClassesForStudentAsync(Guid userId)
    {
        var nowUtc = DateTime.UtcNow;
        var untilUtc = nowUtc.AddDays(14);

        return await _context.Classes
            .AsNoTracking()
            .Where(c => c.UserId == userId && c.StartTime >= nowUtc && c.StartTime < untilUtc)
            .Join(
                _context.Courses.AsNoTracking(),
                cls => cls.CourseId,
                crs => crs.Id,
                (cls, crs) => new ClassDTO
                {
                    StartTime = cls.StartTime,
                    CourseId = cls.CourseId,
                    CourseName = crs.Name,
                    TeacherId = crs.TeacherId
                })
            .OrderBy(dto => dto.StartTime)
            .ToListAsync();
    }


    /// <summary>
    /// Retrieves all upcoming classes taught by a specific teacher within the next 14 days (UTC).
    /// </summary>
    /// <param name="teacherId">The unique identifier of the teacher.</param>
    /// <returns>
    /// A collection of <see cref="ClassDTO"/> objects representing upcoming classes 
    /// associated with the specified teacher. Each item includes:
    /// <list type="bullet">
    ///   <item><description>The class start time (<c>StartTime</c>).</description></item>
    ///   <item><description>The related course ID (<c>CourseId</c>).</description></item>
    ///   <item><description>The course name (<c>CourseName</c>).</description></item>
    ///   <item><description>The teacher ID (<c>TeacherId</c>), corresponding to the current teacher.</description></item>
    /// </list>
    /// </returns>
    public async Task<IEnumerable<ClassDTO>> GetUpcomingClassesForTeacherAsync(Guid teacherId)
    {
        var nowUtc = DateTime.UtcNow;
        var untilUtc = nowUtc.AddDays(14);

        return await _context.Classes
            .AsNoTracking()
            .Where(cls => cls.StartTime >= nowUtc && cls.StartTime < untilUtc)
            .Join(
                _context.Courses.AsNoTracking(),
                cls => cls.CourseId,
                crs => crs.Id,
                (cls, crs) => new { cls, crs }
            )
            .Where(x => x.crs.TeacherId == teacherId)
            .Select(x => new ClassDTO
            {
                StartTime = x.cls.StartTime,
                CourseId  = x.cls.CourseId,
                CourseName = x.crs.Name,
                TeacherId = x.crs.TeacherId
            })
            .OrderBy(dto => dto.StartTime)
            .ToListAsync();
    }
}