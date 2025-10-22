﻿using System.Security.Claims;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using e_learning_backend.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("{teacherId:guid}")]
    public async Task<ActionResult<TeacherDTO>> GetTeacher(Guid teacherId)
    {
        var teacher = await _teacherService.GetTeacherAsync(teacherId);
        if (teacher == null)
        {
            return NotFound(new { message = "Teacher not found" });
        }

        return Ok(teacher);
    }

    [HttpGet("{teacherId}/reviews")]
    public async Task<IActionResult> GetTeacherReviews(Guid teacherId)
    {
        var reviews = await _teacherService.GetTeacherReviewsAsync(teacherId);
        return Ok(reviews);
    }

    [HttpGet("{teacherId}/availability")]
    public async Task<ActionResult<List<TeacherAvailabilityDTO>>> GetAvailability(Guid teacherId)
    {
        var availability = await _teacherService.GetTeacherAvailabilityAsync(teacherId);
        if (availability == null || !availability.Any())
            return NotFound();

        return Ok(availability);
    }
    
    [HttpGet("{teacherId}/students")]
    public async Task<ActionResult<List<TeacherAvailabilityDTO>>> GetStudents(Guid teacherId)
    {
        var students = await _teacherService.GetStudentsByTeacherIdAsync(teacherId);
        return Ok(students);
    }
    
    [HttpGet("{teacherId}/courses")]
    public async Task<ActionResult<List<TeacherAvailabilityDTO>>> GetCourses(Guid teacherId)
    {
        var courses = await _teacherService.GetCoursesByTeacherIdAsync(teacherId);
        return Ok(courses);
    }
    
    [HttpGet("{teacherId:guid}/courses/{courseId:guid}/students")]
    public async Task<IActionResult> GetStudentsInCourse(Guid teacherId, Guid courseId)
    {
        var students = await _teacherService.GetStudentsByTeacherIdAndCourseIdAsync(teacherId, courseId);
        return Ok(students);
    }
    
    [HttpGet("{teacherId:guid}/students/{studentId:guid}/courses")]
    public async Task<IActionResult> GetCoursesOfStudent(Guid teacherId, Guid studentId)
    {
        var students = await _teacherService.GetCoursesByTeacherIdAndStudentIdAsync(teacherId, studentId);
        return Ok(students);
    }
    
    
    [HttpGet("classes-with-students")]
    public async Task<IActionResult> GetClassesWithStudents(CancellationToken ct)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim == null)
            return Unauthorized("Missing NameIdentifier claim in token.");

        if (!Guid.TryParse(userIdClaim, out var teacherId))
            return Unauthorized("Invalid user ID in token.");

        var result = await _teacherService.GetTeacherClassesWithStudentsAsync(teacherId, ct);

        return Ok(result);
    }
}