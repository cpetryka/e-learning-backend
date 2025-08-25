using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ITeacherRepository
{
    Task<TeacherDTO?> GetTeacherAsync(Guid teacherId);
}