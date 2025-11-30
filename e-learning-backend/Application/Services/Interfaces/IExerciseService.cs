using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Application.Services.Interfaces;

public interface IExerciseService
{
    Task<GetExerciseDetailsDTO?> GetByIdAsync(Guid id);
    Task<bool> GradeExerciseAsync(Guid assignmentId, double grade, string? comment, Guid teacherId);

    Task<Guid> CreateExerciseAsync(Guid userId, Guid classId, string instructions,
        IEnumerable<Guid>? fileIds = null);

    Task<Guid> CopyExerciseAsync(Guid userId, Guid exerciseId, Guid classId);
    Task<bool> SubmitExercise(Guid exerciseId, Guid studentId);
    Task<bool> EditExerciseAsync(Guid userId, Guid exerciseId, string? instructions,
        IEnumerable<Guid>? fileIds = null);
    Task<Guid> AddSolutionFileAsync(Guid userId, Guid exerciseId, Guid classId, IFormFile file, CancellationToken ct = default);
    
}