using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl.Services;
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
}