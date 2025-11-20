

using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;

namespace e_learning_backend.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<GetExerciseDetailsDTO?> GetByIdAsync(Guid id)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);

        if (exercise is null)
            return null;

        return new GetExerciseDetailsDTO
        {
            ExerciseId = exercise.Id,
            Grade = exercise.Grade,
            Comment = exercise.Comment,
            TeacherId = exercise.Class.Participation.Course.TeacherId
        };
    }

    public async Task<bool> GradeExerciseAsync(Guid assignmentId, double grade, string? comment, Guid teacherId)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(assignmentId);

        if (exercise is null)
            return false;
        var exerciseTeacherId = exercise.Class?.Participation?.Course?.TeacherId;

        if (exerciseTeacherId is null || exerciseTeacherId != teacherId)
            return false;

        exercise.Grade = grade;
        exercise.Comment = comment;

        await _exerciseRepository.UpdateAsync(exercise); 

        return true;
    }
}