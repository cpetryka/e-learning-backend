

using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

namespace e_learning_backend.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IClassRepository _classRepository;

    public ExerciseService(IExerciseRepository exerciseRepository, IClassRepository classRepository)
    {
        _exerciseRepository = exerciseRepository;
        _classRepository = classRepository;
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
    
    public async Task<Guid> CopyExerciseAsync(Guid userId, Guid exerciseId, Guid classId)
    {
        // Validate source exercise
        var source = await _exerciseRepository.GetByIdAsync(exerciseId);
        if (source == null)
        {
            throw new ArgumentException("Exercise not found.");
        }

        // Validate target class
        var targetClass = await _classRepository.GetByIdAsync(classId);
        if (targetClass == null)
        {
            throw new ArgumentException("Class not found.");
        }

        // Construct new Exercise
        var newExercise = new Exercise(
            Guid.NewGuid(),
            source.Instruction ?? string.Empty,
            targetClass);

        // Handle resources
        foreach (var srcResource in source.ExerciseResources)
        {
            if (srcResource.Type == ExerciseResourceType.Content && srcResource.File != null)
            {
                var reusedResource = new ExerciseResource(newExercise, srcResource.File, srcResource.Type);
                newExercise.AddResource(reusedResource);
            }
        }

        await _exerciseRepository.AddAsync(newExercise);

        return newExercise.Id;
    }
}