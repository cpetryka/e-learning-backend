using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationContext _context;

    public TeacherRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User?> GetTeacherWithDetailsAsync(Guid teacherId)
    {
        return await _context.Users
            .Include(u => u.ConductedCourses)
            .Include(u => u.Availability)
            .ThenInclude(a => a.TimeSlots)
            .Where(u => u.Id == teacherId)
            .Where(u => u.Roles.Any(r => r.RoleName == Role.Teacher.RoleName)) 
            .FirstOrDefaultAsync();
    }

}