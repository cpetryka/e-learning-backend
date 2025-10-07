using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface IClassesService
{
    Task<IEnumerable<ClassDTO>> GetUpcomingClassesForStudentAsync(Guid userId);
    Task<IEnumerable<ClassDTO>> GetUpcomingClassesForTeacherAsync(Guid userId);
}