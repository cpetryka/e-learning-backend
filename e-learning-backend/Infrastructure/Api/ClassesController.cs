using System.Security.Claims;
using System.Text.Json;
using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Extensions;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
    private readonly IClassesService _classesService;

    public ClassesController(IClassesService classesService, ILogger<ClassesController> logger)
    {
        _classesService = classesService;
    }


    [Authorize]
    [HttpGet("upcoming-as-student")]
    public async Task<ActionResult<IEnumerable<ClassDTO>>> GetMyUpcomingAsStudentClassesAsync()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var userId))
            return Unauthorized();

        // roles from standard Role claim(s)
        var roles = User.FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        IEnumerable<ClassDTO> result;
        if (roles.Any(r => r.Equals("student", StringComparison.OrdinalIgnoreCase)))
        {
            result = await _classesService.GetUpcomingClassesForStudentAsync(userId);
        }
        else
        {
            return Forbid();
        }

        if (result == null)
            return NotFound("No upcoming classes found for the current user.");

        return Ok(result);
    }

    [Authorize]
    [HttpGet("upcoming-as-teacher")]
    public async Task<ActionResult<IEnumerable<ClassDTO>>> GetMyUpcomingAsTeacherClassesAsync()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var userId))
            return Unauthorized();


        var roles = User.FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        IEnumerable<ClassDTO> result;
        if (roles.Any(r => r.Equals("teacher", StringComparison.OrdinalIgnoreCase)))
        {
            result = await _classesService.GetUpcomingClassesForTeacherAsync(userId);
        }
        else
        {
            return Forbid();
        }

        if (result == null || !result.Any())
            return NotFound("No upcoming classes found for the current user.");

        return Ok(result);
    }

    [HttpGet("{classId:guid}")]
    public async Task<ActionResult<ClassBriefDto>> GetClassDetails(Guid classId)
    {
        var classDetails = await _classesService.GetClassBriefAsync(classId);

        if (classDetails == null)
        {
            return NotFound();
        }

        return Ok(classDetails);
    }


    [Authorize]
    [HttpPost("{classId:guid}/links")]
    public async Task<IActionResult> AddLink(Guid classId, [FromBody] AddClassLinkDTO dto)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var userId))
        {
            return Unauthorized();
        }

        // Ensure the caller is a teacher
        var roles = User.FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        if (!roles.Any(r => r.Equals("teacher", StringComparison.OrdinalIgnoreCase)))
        {
            return Forbid();
        }

        try
        {
            var success =
                await _classesService.AddLinkAsync(userId, classId, dto.Link, dto.IsMeeting);
            if (!success)
            {
                return Forbid();
            }

            return Created();
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("links/{linkId:guid}")]
    public async Task<IActionResult> RemoveLink(Guid linkId)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var userId))
        {
            return Unauthorized();
        }

        // Ensure caller is teacher
        var roles = User.FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        if (!roles.Any(r => r.Equals("teacher", StringComparison.OrdinalIgnoreCase)))
        {
            return Forbid();
        }

        try
        {
            var success = await _classesService.RemoveLinkAsync(userId, linkId);
            if (!success)
            {
                return Forbid();
            }

            return NoContent();
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{classId:guid}/links")]
    public async Task<IActionResult> GetClassLinks(Guid classId)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        try
        {
            var classDetails = await _classesService.GetClassLinksAsync(classId);
            return Ok(classDetails);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{classId:guid}/files")]
    public async Task<IActionResult> GetClassFiles(Guid classId)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        try
        {
            var classFiles = await _classesService.GetClassFilesAsync(classId);
            return Ok(classFiles);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{classId:guid}/exercises")]
    public async Task<IActionResult> GetClassExercises(Guid classId)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        try
        {
            var classExercises = await _classesService.GetClassExercisesAsync(classId);
            return Ok(classExercises);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddClassWithNewParticipation(
        [FromBody] AddClassWithParticipationDTO dto)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        if (dto == null || dto.CourseId == Guid.Empty || dto.LanguageId == Guid.Empty ||
            dto.LevelId == Guid.Empty)
        {
            return BadRequest("Invalid request payload.");
        }

        try
        {
            var success = await _classesService.AddClassWithParticipationAsync(
                userId.GetValueOrDefault(), dto.CourseId, dto.StartTime, dto.LevelId,
                dto.LanguageId);
            
            if (!success)
            {
                return Forbid();
            }

            return Created(string.Empty, null);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [Authorize]
    [HttpPost("{classId:guid}/files")]
    public async Task<IActionResult> AddFileToClass(Guid classId, [FromBody] string fileId)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var userId))
        {
            return Unauthorized();
        }
        
        var roles = User.FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        if (!roles.Any(r => r.Equals("teacher", StringComparison.OrdinalIgnoreCase)))
        {
            return Forbid();
        }

        if (string.IsNullOrWhiteSpace(fileId) || !Guid.TryParse(fileId, out var fileIdGuid))
        {
            return BadRequest("Invalid file id format.");
        }

        try
        {
            var success = await _classesService.AddFileToClassAsync(userId, classId, fileIdGuid);
            if (!success)
            {
                return Forbid();
            }

            return Created();
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}