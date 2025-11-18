// e_learning_backend/Api/Files/UserFilesController.cs
using System.Security.Claims;
using e_learning_backend.Application.Files;
using e_learning_backend.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Api.Files;

[ApiController]
[Route("api/user/files")]
[Authorize] // wymagamy JWT
public class UserFilesController : ControllerBase
{
    private readonly IUsersFilesService _service;

    public UserFilesController(IUsersFilesService service) => _service = service;
    
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get(
        [FromQuery] IEnumerable<Guid>? tags,
        [FromQuery] IEnumerable<string>? types,
        [FromQuery] Guid? studentId,
        [FromQuery] Guid? courseId,
        [FromQuery] IEnumerable<Guid>? createdBy,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken ct = default)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        var result = await _service.GetUserFilesAsync(
            currentUserId,
            tags,
            types,
            studentId,
            courseId,
            createdBy,
            page,
            pageSize,
            ct);

        return Ok(result);
    }
    
    [HttpPost]
    [RequestSizeLimit(50 * 1024 * 1024)]
    [Consumes("multipart/form-data")]
    [Authorize]
    public async Task<IActionResult> Post(IFormFile file, CancellationToken ct)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        var result = await _service.UploadAsync(currentUserId, file, ct);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }
    
    [HttpPost("profile-picture")]
    [RequestSizeLimit(5 * 1024 * 1024)] // maks. 5 MB dla zdjęcia profilowego
    [Consumes("multipart/form-data")]
    [Authorize]
    public async Task<IActionResult> UploadProfilePicture(IFormFile file, CancellationToken ct)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        if (file is null)
            return BadRequest("No file uploaded.");

        try
        {
            var result = await _service.UploadProfilePictureAsync(currentUserId, file, ct);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            // Dla bezpieczeństwa nie ujawniamy szczegółów błędu użytkownikowi
            return StatusCode(500, new { error = "Wystąpił nieoczekiwany błąd.", details = ex.Message });
        }
    }

    [HttpGet("tags")]
    [Authorize]
    public async Task<IActionResult> GetTags()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");
        
        var result = await _service.GetUserFileTags(Guid.Parse(userId), CancellationToken.None);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(Guid fileId, CancellationToken ct)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");
        var deleted = await _service.DeleteFile(Guid.Parse(userId), fileId);
        return Ok(deleted);
        
    }
    

    [HttpGet("extensions")]
    [Authorize]
    public async Task<IActionResult> GetExtensions(CancellationToken ct)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        var extensions = await _service.GetFileExtensionsByUserIdAsync(currentUserId, ct);
        return Ok(extensions);
    }
    
    [HttpGet("owners")]
    [Authorize]
    public async Task<IActionResult> GetClassFileOwners(CancellationToken ct)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        var owners = await _service.GetClassFileOwnersAsync(currentUserId, ct);
        return Ok(owners);
    }





}
