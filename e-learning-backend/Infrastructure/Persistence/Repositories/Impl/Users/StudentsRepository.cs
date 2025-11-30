using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public class StudnetsRepository : IStudentsRepository
{
    private readonly ApplicationContext _context;

    public StudnetsRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User?> GetStudentWithCoursesAsync(Guid studentId)
    {
        return await _context.Users
            .Include(u => u.Participations)
            .ThenInclude(p => p.Course)
            .Where(u => u.Id == studentId)
            .Where(u => u.Roles.Any(r => r.RoleName == Role.Student.RoleName))
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<CourseBriefDTO>> GetStudentCourses(Guid studentId)
    {
        return await _context.Participations
            .Where(p => p.UserId == studentId)
            .Distinct()
            .Select(p => new CourseBriefDTO
            {
                Id = p.Course.Id,
                Name = p.Course.Name
            })
            .ToListAsync();
    }
    
    public async Task<IEnumerable<GetExerciseDTO>> GetAllExercisesByStudentIdAsync(Guid studentId, Guid? courseId)
    {
        return await _context.Exercises
            .Include(e => e.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.Course)
            .Include(e => e.ExerciseResources)
            .ThenInclude(e => e.File)
            .Where(e => e.Class.Participation.UserId == studentId)
            .Where(e => courseId == null || e.Class.Participation.CourseId == courseId)
            .Select(e => new GetExerciseDTO()
            {
                Id = e.Id,
                ClassId = e.Class.Id,
                Name = e.Class.Participation.Course.Name + " [" + e.Class.StartTime.ToString("yyyy-MM-dd") + "]",
                CourseName = e.Class.Participation.Course.Name,
                Status = e.Status.ToString(),
                Graded = e.Grade != null,
                Grade = e.Grade,
                Comments = e.Comment ?? "",
                Instruction = e.Instruction ?? "",
                Date = e.Class.StartTime,
                Files = e.ExerciseResources.Select(er => new GetExerciseResourceDTO()
                {
                    Id = er.FileId,
                    Name = er.File.Name,
                    Path = er.File.Path,
                    Type = er.Type.ToString().ToLower(),
                    UploadDate = er.File.AddedAt
                }).ToList()
            })
            .ToListAsync();
    }
}