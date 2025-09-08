using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using e_learning_backend.Application.Services;
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
}