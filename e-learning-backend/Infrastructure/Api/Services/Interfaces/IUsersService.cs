using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface IUsersService
{
    Task<AboutMeDTO?> GetAboutMeAsync(Guid userId);

    Task<(bool Success, string Message, ProfilePicture? ProfilePicture)> UploadProfilePictureAsync(Guid userId, IFormFile file);
}