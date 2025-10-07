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
}