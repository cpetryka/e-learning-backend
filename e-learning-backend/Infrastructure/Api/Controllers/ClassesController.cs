using System.Security.Claims;
using System.Text.Json;
using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ClassesController :ControllerBase
{
    private readonly IClassesService _classesService;
    
    public ClassesController(IClassesService classesService, ILogger<ClassesController> logger)
    {
        _classesService = classesService;
    }
    
    
    [Authorize]
    [HttpGet("upcoming")]
    public async Task<ActionResult<IEnumerable<ClassDTO>>> GetMyUpcomingClassesAsync()
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
        if (roles.Any(r => r.Equals("teacher", StringComparison.OrdinalIgnoreCase)))
        {
            result = await _classesService.GetUpcomingClassesForTeacherAsync(userId);
        }
        else if (roles.Any(r => r.Equals("student", StringComparison.OrdinalIgnoreCase)))
        {
            result = await _classesService.GetUpcomingClassesForStudentAsync(userId);
        }
        else
        {
            return Forbid();
        }

        if (result == null || !result.Any())
            return NotFound("No upcoming classes found for the current user.");

        return Ok(result);
    }

}