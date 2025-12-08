using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ITeacherService
{
    Task<TeacherDTO?> GetTeacherAsync(Guid teacherId);
    Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviewsAsync(Guid teacherId);
    Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId);
    Task<bool> AddAvailabilityAsync(Guid teacherId, List<AddDayAvailabilityDTO> availability, CancellationToken ct = default);
    Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAndCourseIdAsync(Guid teacherId, Guid courseId);
    Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAndStudentIdAsync(Guid teacherId, Guid studentId);

    Task<IEnumerable<ExerciseDTO>> GetExercisesByTeacherIdAndStudentIdAsync(
        Guid teacherId, Guid studentId, Guid? courseId);

    Task<IEnumerable<QuizSummaryDTO>> GetQuizzesByTeacherIdAndStudentIdAsync(
        Guid teacherId, Guid studentId, Guid? courseId);
    Task<IReadOnlyList<ClassWithStudentsDTO>> GetTeacherClassesWithStudentsAsync(
        Guid teacherId, CancellationToken cancellationToken = default);

    Task<IEnumerable<TeacherUpcomingClass>> GetUpcomingClassesAsync(Guid teacherId,
        DateOnly start, DateOnly end);
    Task<IEnumerable<ExerciseBriefDTO>> GetExercisesToGradeAsync(Guid teacherId, 
        List<Guid>? courseIds = null, List<Guid>? studentIds = null);
}