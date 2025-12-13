using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Application.Services;

public class TeachersService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeachersService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<TeacherDTO?> GetTeacherAsync(Guid teacherId)
    {
        var teacher = await _teacherRepository.GetTeacherWithDetailsAsync(teacherId);
        if (teacher == null) return null;

        return new TeacherDTO
        {
            TeacherId = teacher.Id,
            Name = teacher.Name,
            Surname = teacher.Surname,
            Description = teacher.AboutMe,
            CoursesBrief = teacher.ConductedCourses
                .Select(c => new TeacherDTO.CourseBriefDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
            TeacherProfilePictureUrl = teacher.ProfilePicture != null
                ? "http://localhost:5249/" + teacher.ProfilePicture.FilePath.Replace("\\", "/")
                : null
        };
    }

    public async Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviewsAsync(Guid teacherId)
    {
        return await _teacherRepository.GetTeacherReviews(teacherId);
    }


    public async Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId)
    {
        return await _teacherRepository.GetTeacherAvailabilityAsync(teacherId);
    }
    
    public async Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAsync(Guid teacherId)
    {
        return await _teacherRepository.GetStudentsByTeacherIdAsync(teacherId);
    }
    
    public async Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAsync(Guid teacherId)
    {
        return await _teacherRepository.GetCoursesByTeacherIdAsync(teacherId);
    }
    
    public async Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAndCourseIdAsync(Guid teacherId, Guid courseId)
    {
        return await _teacherRepository.GetStudentsByTeacherIdAndCourseIdAsync(teacherId, courseId);
    }
    
    public async Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAndStudentIdAsync(Guid teacherId, Guid studentId)
    {
        return await _teacherRepository.GetCoursesByTeacherIdAndStudentIdAsync(teacherId, studentId);
    }

    public async Task<IEnumerable<ExerciseDTO>> GetExercisesByTeacherIdAndStudentIdAsync(
        Guid teacherId, Guid studentId, Guid? courseId)
    {
        return await _teacherRepository.GetExercisesByTeacherIdAndStudentIdAsync(
            teacherId, studentId, courseId);
    }
    
    public async Task<IEnumerable<QuizSummaryDTO>> GetQuizzesByTeacherIdAndStudentIdAsync(
        Guid teacherId, Guid studentId, Guid? courseId)
    {
        return await _teacherRepository.GetQuizzesByTeacherIdAndStudentIdAsync(
            teacherId, studentId, courseId);
    }

    public async Task<IReadOnlyList<ClassWithStudentsDTO>> GetTeacherClassesWithStudentsAsync(Guid teacherId, CancellationToken cancellationToken = default)
    {
        var data = await _teacherRepository.GetClassesWithStudentsByTeacherIdAsync(teacherId);
        var list = data?.ToList() ?? new List<ClassWithStudentsDTO>();
        return list;
    }
    
    public async Task<IEnumerable<TeacherUpcomingClass>> GetUpcomingClassesAsync(Guid teacherId,
        DateOnly start, DateOnly end)
    {
        return await _teacherRepository.GetUpcomingClassesAsync(teacherId, start, end);
    }
    
    public async Task<IEnumerable<ExerciseBriefDTO>> GetExercisesToGradeAsync(
        Guid teacherId, List<Guid>? courseIds = null, List<Guid>? studentIds = null)
    {
        return await _teacherRepository.GetExercisesToGradeAsync(teacherId, courseIds, studentIds);
    }

    public async Task<bool> AddAvailabilityAsync(Guid teacherId, List<TeacherAvailabilityDTO> availability, CancellationToken ct = default)
    {
        return await _teacherRepository.AddAvailabilityAsync(teacherId, availability, ct);
    }
}