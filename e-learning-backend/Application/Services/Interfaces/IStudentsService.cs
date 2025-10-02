using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface IStudentsService 
{
    Task<StudentDTO?> GetStudentWithCoursesAsync(Guid studentId);
    
    Task<IEnumerable<ClassBriefDto>> GetTimelineAsync(
        Guid studentId,
        IEnumerable<Guid>? participationIds,
        DateTime from,
        DateTime to);
}