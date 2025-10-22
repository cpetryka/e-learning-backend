﻿using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ITeacherService
{
    Task<TeacherDTO?> GetTeacherAsync(Guid teacherId);
    Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviewsAsync(Guid teacherId);
    Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId);
    Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAndCourseIdAsync(Guid teacherId, Guid courseId);
    Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAndStudentIdAsync(Guid teacherId, Guid studentId);
    Task<IReadOnlyList<ClassWithStudentsDTO>> GetTeacherClassesWithStudentsAsync(Guid teacherId, CancellationToken cancellationToken = default);
}