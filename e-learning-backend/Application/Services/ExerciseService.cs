using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using Microsoft.AspNetCore.Http;

namespace e_learning_backend.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IClassRepository _classRepository;
    private readonly IFileResourceRepository _fileResourceRepository;
    private readonly IUsersFilesService _usersFilesService;

    public ExerciseService(IExerciseRepository exerciseRepository, IClassRepository classRepository,
        IFileResourceRepository fileResourceRepository, IUsersFilesService usersFilesService)
    {
        _exerciseRepository = exerciseRepository;
        _classRepository = classRepository;
        _fileResourceRepository = fileResourceRepository;
        _usersFilesService = usersFilesService;
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

    public async Task<bool> GradeExerciseAsync(Guid assignmentId, double grade, string? comment,
        Guid teacherId)
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
    
    public async Task<bool> SubmitExercise(Guid exerciseId, Guid studentId)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(exerciseId);

        if (exercise is null)
            return false;
        var exerciseStudentId = exercise.Class?.Participation?.User.Id;

        if (exerciseStudentId is null || exerciseStudentId != studentId)
            return false;

        exercise.Status = ExerciseStatus.Submitted;

        await _exerciseRepository.UpdateAsync(exercise);

        return true;
    }

    public async Task<Guid> CreateExerciseAsync(Guid userId, Guid classId, string instructions,
        IEnumerable<Guid>? fileIds = null)
    {
        // Check if the target class exists
        var targetClass = await _classRepository.GetByIdAsync(classId);
        if (targetClass == null)
        {
            throw new ArgumentException("Class not found.");
        }

        // Create a new exercise
        var newExercise = new Exercise(Guid.NewGuid(), instructions ?? string.Empty, targetClass);

        // Attach files if provided
        if (fileIds != null)
        {
            foreach (var fileId in fileIds)
            {
                var file = await _fileResourceRepository.GetByIdAsync(fileId);
                if (file == null)
                {
                    throw new ArgumentException($"File with id {fileId} not found.");
                }

                newExercise.addContentFile(file);
            }
        }

        await _exerciseRepository.AddAsync(newExercise);

        return newExercise.Id;
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
                var reusedResource =
                    new ExerciseResource(newExercise, srcResource.File, srcResource.Type);
                newExercise.AddResource(reusedResource);
            }
        }

        await _exerciseRepository.AddAsync(newExercise);

        return newExercise.Id;
    }

    public async Task<bool> EditExerciseAsync(Guid userId, Guid exerciseId, string? instructions,
        IEnumerable<Guid>? fileIds = null)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(exerciseId);
        if (exercise == null)
        {
            throw new ArgumentException("Exercise not found.");
        }

        // Only allow editing when status is Unsolved
        if (exercise.Status != ExerciseStatus.Unsolved)
        {
            throw new InvalidOperationException(
                "Exercise can be edited only when its status is Unsolved.");
        }

        // Only course teacher can edit
        var exerciseTeacherId = exercise.Class?.Participation?.Course?.TeacherId;
        if (exerciseTeacherId is null || exerciseTeacherId != userId)
        {
            return false;
        }

        // Update instruction when provided (allow empty string)
        if (instructions != null)
        {
            exercise.Instruction = instructions;
        }

        // Fetch current content resources snapshot
        var existingContent = exercise.ExerciseResources
            .Where(er => er.Type == ExerciseResourceType.Content)
            .ToList();

        // Remove all content files when fileIds is not sent
        if (fileIds == null)
        {
            foreach (var res in existingContent)
            {
                exercise.RemoveResource(res);
            }
        }
        else
        {
            var requestedIds = new HashSet<Guid>(fileIds);

            // Remove resources that are not requested anymore
            var toRemove = existingContent.Where(er => !requestedIds.Contains(er.FileId)).ToList();
            foreach (var res in toRemove)
            {
                exercise.RemoveResource(res);
            }

            // Determine which file IDs still need to be added
            var remainingIds = exercise.ExerciseResources
                .Where(er => er.Type == ExerciseResourceType.Content)
                .Select(er => er.FileId)
                .ToHashSet();

            var toAdd = requestedIds.Except(remainingIds);
            foreach (var fileId in toAdd)
            {
                var file = await _fileResourceRepository.GetByIdAsync(fileId);
                if (file == null)
                    throw new ArgumentException($"File with id {fileId} not found.");

                // Create a new ExerciseResource which links the exercise and file (adds to both sides)
                _ = new ExerciseResource(exercise, file, ExerciseResourceType.Content);
            }
        }

        await _exerciseRepository.UpdateAsync(exercise);
        return true;
    }     

    public async Task<Guid> AddSolutionFileAsync(Guid userId, Guid exerciseId, Guid classId, IFormFile file, CancellationToken ct = default)
    {
        
        var exercise = await _exerciseRepository.GetByIdAsync(exerciseId);
        if (exercise == null)
        {
            throw new ArgumentException("Exercise not found.");
        }
        
        /*var targetClass = await _classRepository.GetByIdAsync(exercise.ClassId);
        if (targetClass == null)
        {
            throw new ArgumentException("Class not found.");
        }*/
        
        /*if (exercise.ClassId != classId)
        {
            throw new ArgumentException("Exercise does not belong to the specified class.");
        }*/
        
        var exerciseStudentId = exercise.Class?.Participation?.User.Id;
        var exerciseTeacherId = exercise.Class?.Participation?.Course?.TeacherId;
        
        if (exerciseStudentId != userId && exerciseTeacherId != userId)
        {
            throw new UnauthorizedAccessException("User does not have permission to add solution to this exercise.");
        }
        
        var uploadResult = await _usersFilesService.UploadAsync(userId, file, ct);
        
        var fileResource = await _fileResourceRepository.GetByIdAsync(uploadResult.Id);
        if (fileResource == null)
        {
            throw new InvalidOperationException("File was uploaded but could not be retrieved.");
        }
        
        // targetClass.AddFile(fileResource);
        
        exercise.addSolutionFile(fileResource);
        
        await _exerciseRepository.UpdateAsync(exercise);
        // await _classRepository.UpdateAsync(targetClass);

        return uploadResult.Id;
    }
}