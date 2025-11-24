using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Application.Services.Interfaces;

public interface IExerciseService
{
    Task<GetExerciseDetailsDTO?> GetByIdAsync(Guid id);
    Task<bool> GradeExerciseAsync(Guid assignmentId, double grade, string? comment, Guid teacherId);
    Task<Guid> CopyExerciseAsync(Guid userId, Guid exerciseId, Guid classId);
}