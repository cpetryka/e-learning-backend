using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.Repositories;

[ApiController]
[Route("api/profile-picture")]
public class ProfilePictureController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    private readonly IUsersRepository _userRepository;
    private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

    public ProfilePictureController(IWebHostEnvironment env, IUsersRepository userRepository)
    {
        _env = env;
        _userRepository = userRepository;
    }

    [HttpPost("upload")]
    [Authorize] 
    public async Task<IActionResult> UploadProfilePicture(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        if (file.Length > MaxFileSize)
            return BadRequest("File is too large. Maximum allowed size is 5 MB.");

        
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
            return BadRequest("Invalid file type. Only JPG, JPEG, PNG, GIF, and WEBP are allowed.");

        
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null)
            return Unauthorized();

        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        // Pobranie użytkownika z repozytorium
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            return NotFound("User not found.");

        
        var uploadsFolder = Path.Combine(_env.WebRootPath ?? throw new InvalidOperationException("WebRootPath not set"), "uploads", "users", userId.ToString());
        Directory.CreateDirectory(uploadsFolder);
        
        var fileName = $"profile-picture{extension}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        
        var profilePicture = new ProfilePicture(
            fileName,
            Path.Combine("uploads", "users", userId.ToString(), fileName)
        );
        
        user.SetProfilePicture(profilePicture);
        await _userRepository.UpdateAsync(user);

        return Ok(new
        {
            fileName = profilePicture.FileName,
            filePath = profilePicture.FilePath,
            uploadedAt = profilePicture.UploadedAt
        });
    }
}
