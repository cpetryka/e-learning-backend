using e_learning_backend.API.DTOs;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class ClassesService : IClassesService
{   private readonly IClassRepository _repository;
    
    public ClassesService(IClassRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Retrieves all upcoming classes for a specific student within the next 14 days (UTC).
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    public Task<IEnumerable<ClassDTO>> GetUpcomingClassesForStudentAsync(Guid studentId)
        => _repository.GetUpcomingClassesForStudentAsync(studentId);

    
    /// <summary>
    /// Retrieves all upcoming classes for a specific teacher within the next 14 days (UTC).
    /// </summary>
    /// <param name="teacherId">The unique identifier of the teacher.</param>
    public Task<IEnumerable<ClassDTO>> GetUpcomingClassesForTeacherAsync(Guid teacherId) 
        => _repository.GetUpcomingClassesForTeacherAsync(teacherId);
    
    public async Task<ClassBriefDto?> GetClassBriefAsync(Guid classId)
    {
        var cls = await _repository.GetByIdAsync(classId);
        
        if (cls == null)
            return null;
        
        var dto = new ClassBriefDto
        {
            Id = cls.Id,
            StartTime = cls.StartTime,
            Status = cls.Status.Status,
            LinkToMeeting = cls.LinkToMeeting,
            Links = (cls.LinkToMeeting != null
                ? new[] { cls.LinkToMeeting }.Concat(cls.Links.Select(link => link.Link))
                : cls.Links.Select(link => link.Link)),
            UserId = cls.UserId,
            CourseId = cls.CourseId,
            CourseName = cls.Participation.Course.Name ?? "Unknown",

            Exercises = cls.Exercises.Select(ex => new ExercisePreviewDto
            {
                Id = ex.Id,
                ExerciseStatus = ex.Status.ToString(),
                Grade = ex.Grade
            }),

            Quizzes = cls.Quizzes.Select(qz => new QuizPreviewDto
            {
                Id = qz.Id,
                Score = qz.Score
            }),

            Files = cls.Files.Select(f => new FilePreviewDto
            {
                Id = f.Id,
                Name = f.Name,
                Path = f.Path
            })
        };

        return dto;
    }
}