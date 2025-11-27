using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentsService _studentsService;
    private readonly IParticipationRepository _participationRepository;
    private readonly IStudentsRepository _studentsRepository;

    public StudentsController(IStudentsService studentsService,
        IParticipationRepository participationRepository, IStudentsRepository studentsRepository)
    {
        _studentsService = studentsService;
        _participationRepository = participationRepository;
        _studentsRepository = studentsRepository;
    }

    [HttpGet("{studentId:guid}")]
    public async Task<IActionResult> GetStudentWithCourses(Guid studentId)
    {
        var student = await _studentsService.GetStudentWithCoursesAsync(studentId);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpGet("{studentId:guid}/participations")]
    public async Task<IActionResult> GetStudentParticipations(Guid studentId)
    {
        var participations = await _participationRepository.GetBriefByUserIdAsync(studentId);

        var participationList = participations.ToList();

        if (participationList.Count == 0)
            return NotFound();

        return Ok(participationList);
    }

    [HttpGet("{studentId:guid}/timeline")]
    public async Task<IActionResult> GetStudentTimeline(
        Guid studentId,
        [FromQuery] DateTime? from = null,
        [FromQuery] DateTime? to = null,
        [FromQuery] List<Guid>? participationIds = null)
    {
        var startDate = from ?? DateTime.UtcNow.AddDays(-30);
        var endDate = to ?? DateTime.UtcNow;

        var timeline =
            await _studentsService.GetTimelineAsync(studentId, participationIds, startDate,
                endDate);

        return Ok(timeline);
    }

    [HttpGet("{studentId:guid}/courses")]
    public async Task<IActionResult> GetStudentCourses(Guid studentId)
    {
        var courses = await _studentsService.GetStudentCoursesAsync(studentId);

        return Ok(courses);
    }

    [HttpGet("{studentId:guid}/exercises")]
    public async Task<IActionResult> GetAllExercisesByStudentIdAsync(Guid studentId,
        [FromQuery] Guid? courseId)
    {
        var exercises =
            await _studentsRepository.GetAllExercisesByStudentIdAsync(studentId, courseId);

        return Ok(exercises);
    }

    [HttpGet("{studentId:guid}/classes")]
    public async Task<IActionResult> GetAllExercisesByStudentIdAsync(Guid studentId,
        [FromQuery] DateTime? from = null,
        [FromQuery] DateTime? to = null,
        [FromQuery] List<Guid>? participationIds = null)
    {
        var startDate = from ?? DateTime.UtcNow.AddDays(-30);
        var endDate = to ?? DateTime.UtcNow.AddDays(14);

        var classes =
            await _studentsService.GetAllClassesByStudentIdAsync(studentId, participationIds,
                startDate, endDate);
        return Ok(classes);
    }
}