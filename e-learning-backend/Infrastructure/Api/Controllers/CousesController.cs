using System.Security.Claims;
using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICoursesService _coursesService;

    public CoursesController(ICoursesService coursesService)
    {
        _coursesService = coursesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseWidgetDTO>>> GetCourses(
        [FromQuery] string[]? categories,
        [FromQuery] string[]? levels,
        [FromQuery] string[]? languages,
        [FromQuery] int? priceFrom,
        [FromQuery] int? priceTo,
        [FromQuery] Guid? teacherId)
    {
        var courses = await _coursesService.GetCoursesAsync(
            categories,
            levels,
            languages,
            priceFrom,
            priceTo,
            teacherId);

        return Ok(courses);
    }
   
    
    [HttpGet("{courseId}")]
    public async Task<ActionResult<CourseDetailsDTO>> GetCourseDetails(Guid courseId)
    {
        var courseDetails = await _coursesService.GetCourseDetailsAsync(courseId);
        if (courseDetails == null)
            return NotFound();

        return Ok(courseDetails);
    }
    
    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyCollection<CourseCategory>>> GetDistinctCategories()
    {
        var categories = await _coursesService.GetAllDistinctCategoriesAsync();
        return Ok(categories);
    }
    [HttpGet("levels")]
    public async Task<ActionResult<IReadOnlyCollection<CourseLevel>>> GetDistinctLevels()
    {
        var levels = await _coursesService.GetAllDistinctLevelsAsync();
        return Ok(levels);
    }
    [HttpGet("languages")]
    public async Task<ActionResult<IReadOnlyCollection<CourseLanguage>>> GetDistinctLanguages()
    {
        var languages = await _coursesService.GetAllDistinctLanguagesAsync();
        return Ok(languages);
    }
    [HttpPost("{courseId}/profile-picture/upload")]
    [Authorize]
    public async Task<IActionResult> UploadCourseProfilePicture(Guid courseId, IFormFile file)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        var result = await _coursesService.UploadProfilePictureAsync(courseId, userId, file);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(new
        {
            fileName = result.ProfilePicture?.FileName,
            filePath = result.ProfilePicture?.FilePath,
            uploadedAt = result.ProfilePicture?.UploadedAt
        });
    }
}