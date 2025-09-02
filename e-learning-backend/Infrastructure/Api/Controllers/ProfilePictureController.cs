using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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

        
        var userIdClaim = User.FindFirst("id")?.Value;
        if (userIdClaim == null)
            return Unauthorized();

        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            return NotFound("User not found.");
        
        
        var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "users", userId.ToString());
        Directory.CreateDirectory(uploadsFolder);

        // Zawsze zapisujemy jako "profile-picture" z oryginalnym rozszerzeniem pliku
        var fileName = $"profile-picture{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);


        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Utworzenie VO ProfilePicture
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
