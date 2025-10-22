﻿using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ITeacherRepository
{
    Task<User?> GetTeacherWithDetailsAsync(Guid teacherId);
    Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviews(Guid teacherId);
    Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId);
    Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAsync(Guid teacherId);
    Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAndCourseIdAsync(Guid teacherId, Guid courseId);
    Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAndStudentIdAsync(Guid teacherId, Guid studentId);
    Task<IEnumerable<ClassWithStudentsDTO>> GetClassesWithStudentsByTeacherIdAsync(Guid teacherId);

}