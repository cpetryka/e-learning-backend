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

    public StudentsController(IStudentsService studentsService)
    {
        _studentsService = studentsService;
    }

    [HttpGet("{studentId:guid}")]
    public async Task<IActionResult> GetStudentWithCourses(Guid studentId)
    {
        var student = await _studentsService.GetStudentWithCoursesAsync(studentId);

        if (student == null)
            return NotFound();

        return Ok(student);
    }
}