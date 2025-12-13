using System.Security.Claims;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using e_learning_backend.Application.Services;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherRepository teacherRepository, ITeacherService teacherService)
    {
        _teacherRepository = teacherRepository;
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

    [HttpPost("{teacherId:guid}/availability")]
    [Authorize]
    public async Task<IActionResult> AddAvailability(Guid teacherId, [FromBody] List<TeacherAvailabilityDTO> availability, CancellationToken ct = default)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        if (currentUserId != teacherId)
            return Forbid("You can only add availability for yourself.");

        var success = await _teacherService.AddAvailabilityAsync(teacherId, availability, ct);
        
        if (!success)
            return BadRequest("Failed to add availability.");

        return NoContent();
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
    
    [HttpGet("{teacherId:guid}/students/{studentId:guid}/exercises")]
    public async Task<IActionResult> GetExercisesOfStudent(Guid teacherId, Guid studentId, [FromQuery] Guid? courseId)
    {
        var students = await _teacherService.GetExercisesByTeacherIdAndStudentIdAsync(teacherId, studentId, courseId);
        return Ok(students);
    }
    
    [HttpGet("{teacherId:guid}/students/{studentId:guid}/quizzes")]
    public async Task<IActionResult> GetQuizzesOfStudent(Guid teacherId, Guid studentId, [FromQuery] Guid? courseId)
    {
        var students = await _teacherService.GetQuizzesByTeacherIdAndStudentIdAsync(teacherId, studentId, courseId);
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
    
    [HttpGet("{teacherId}/upcoming-classes")]
    public async Task<ActionResult<List<TeacherUpcomingClass>>> GetUpcomingClasses(Guid teacherId, [FromQuery] DateOnly start, [FromQuery] DateOnly end)
    {
        var upcomingClasses = await _teacherService.GetUpcomingClassesAsync(teacherId, start, end);
        return Ok(upcomingClasses);
    }
    
    [HttpGet("exercises-to-grade")]
    public async Task<IActionResult> GetExercisesToGrade([FromQuery] List<Guid>? courseIds = null, [FromQuery] List<Guid>? studentIds = null)
    {
        
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (userIdClaim == null)
            return Unauthorized("Missing NameIdentifier claim in token.");

        if (!Guid.TryParse(userIdClaim, out var teacherId))
            return Unauthorized("Invalid user ID in token.");
        var exercises = await _teacherService.GetExercisesToGradeAsync(teacherId, courseIds, studentIds);
        return Ok(exercises);
    }
    
    [HttpGet("{teacherId:guid}/exercises")]
    public async Task<IActionResult> GetAllExercisesByTeacherId(Guid teacherId, [FromQuery] Guid? courseId, [FromQuery] Guid? studentId)
    {
        var exercises = await _teacherRepository.GetAllExercisesByTeacherIdAsync(teacherId, courseId, studentId);
        return Ok(exercises);
    }
}