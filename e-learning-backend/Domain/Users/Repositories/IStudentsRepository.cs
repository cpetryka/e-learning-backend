using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IStudentsRepository
{
    Task<User?> GetStudentWithCoursesAsync(Guid studentId);
    Task<IEnumerable<CourseBriefDTO>> GetStudentCourses(Guid studentId);
    Task<IEnumerable<GetExerciseDTO>> GetAllExercisesByStudentIdAsync(Guid teacherId, Guid? courseId);
}