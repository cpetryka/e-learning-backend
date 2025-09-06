using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Infrastructure.Api.Services;

public class StudentsService : IStudentsService
{
    private readonly IStudentsRepository _studentsRepository;

    public StudentsService(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task<StudentDTO?> GetStudentWithCoursesAsync(Guid studentId)
    {
        var student = await _studentsRepository.GetStudentWithCoursesAsync(studentId);

        if (student == null) return null;

        return new StudentDTO
        {
            Name = $"{student.Name} {student.Surname}",
            CoursesBrief = student.Participations
                .Select(p => new StudentDTO.CourseBriefDTO
                {
                    Id = p.Course.Id,
                    Name = p.Course.Name
                })
                .ToList()
        };
    }
}