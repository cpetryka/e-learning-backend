using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface IClassesService
{
    Task<IEnumerable<ClassDTO>> GetUpcomingClassesForStudentAsync(Guid userId);
    Task<IEnumerable<ClassDTO>> GetUpcomingClassesForTeacherAsync(Guid userId);
    Task<ClassBriefDto?> GetClassBriefAsync(Guid classId);
}