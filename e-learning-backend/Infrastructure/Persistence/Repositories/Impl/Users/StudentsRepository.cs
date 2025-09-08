using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
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
}