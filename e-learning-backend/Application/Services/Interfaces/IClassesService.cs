using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface IClassesService
{
    Task<IEnumerable<ClassDTO>> GetUpcomingClassesForStudentAsync(Guid userId);
    Task<IEnumerable<ClassDTO>> GetUpcomingClassesForTeacherAsync(Guid userId);
    Task<ClassBriefDto?> GetClassBriefAsync(Guid classId);
    Task<bool> AddLinkAsync(Guid userId, Guid classId, string link, bool isMeeting);
    Task<bool> RemoveLinkAsync(Guid userId, Guid linkId);
    Task<IEnumerable<GetClassLinkDTO>> GetClassLinksAsync(Guid classId);
    Task<IEnumerable<GetClassFileDTO>> GetClassFilesAsync(Guid classId);
    Task<IEnumerable<GetExerciseDTO>> GetClassExercisesAsync(Guid classId);
    Task<bool> AddClassWithParticipationAsync(Guid studentId, Guid courseId, DateTime startTime,
        Guid? levelId, Guid? languageId);

    Task<bool> AddFileToClassAsync(Guid userId, Guid classId, Guid fileId);
}