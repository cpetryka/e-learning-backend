using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;

namespace e_learning_backend.Infrastructure.Security.Impl.Services;

public interface ITeacherService
{
    Task<TeacherDTO?> GetTeacherAsync(Guid teacherId);
}

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<TeacherDTO?> GetTeacherAsync(Guid teacherId)
    {
        var teacher = await _teacherRepository.GetTeacherWithDetailsAsync(teacherId);
        if (teacher == null) return null;

        return new TeacherDTO
        {
            Name = teacher.Name,
            Surname = teacher.Surname,
            Description = teacher.AboutMe,
            CoursesBrief = teacher.ConductedCourses
                .Select(c => new TeacherDTO.CourseBriefDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
            Availability = teacher.Availability
                .Select(a => new TeacherDTO.AvailabilityDTO
                {
                    Day = DateOnly.FromDateTime(a.Date),
                    Timeslots = a.TimeSlots.Select(ts => new TeacherDTO.TimeslotDTO
                    {
                        TimeFrom = TimeOnly.FromDateTime(ts.StartTime),
                        TimeUntil = TimeOnly.FromDateTime(ts.EndTime)
                    }).ToList()
                }).ToList(),
        };
    }
}