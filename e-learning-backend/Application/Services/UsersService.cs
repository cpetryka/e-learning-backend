using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IWebHostEnvironment _env;

    private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB
    private readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

    public UsersService(IUsersRepository usersRepository, IWebHostEnvironment env)
    {
        _usersRepository = usersRepository;
        _env = env;
    }

    public async Task<AboutMeDTO?> GetAboutMeAsync(Guid userId)
    {
        var user = await _usersRepository.GetByIdAsync(userId);
        if (user == null) return null;

        return new AboutMeDTO
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            PhoneNumber = user.Phone,
            Description = user.AboutMe,
        };
    }

    public async Task<(bool Success, string Message, ProfilePicture? ProfilePicture)>
        UploadProfilePictureAsync(Guid userId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return (false, "No file uploaded.", null);
        if (file.Length > MaxFileSize)
            return (false, "File is too large.", null);

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(extension))
            return (false, "Invalid file type.", null);

        var user = await _usersRepository.GetByIdAsync(userId);
        if (user == null)
            return (false, "User not found.", null);

        var uploadsFolder = Path.Combine(_env.WebRootPath!, "uploads", "users", userId.ToString());
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"profile-picture{extension}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        var profilePicture = new ProfilePicture(fileName,
            Path.Combine("uploads", "users", userId.ToString(), fileName));
        user.SetProfilePicture(profilePicture);
        await _usersRepository.UpdateAsync(user);

        return (true, "File uploaded successfully.", profilePicture);
    }
    public Task<bool> ExistsAsync(Guid userId)
        => _usersRepository.ExistsAsync(userId);
    public Task<Guid?> GetIdByEmailAsync(string email) 
        => _usersRepository.GetIdByEmailAsync(email);
}