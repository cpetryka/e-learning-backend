using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ICoursesService
{
    Task<IEnumerable<CourseWidgetDTO>> GetCoursesAsync(
        string[]? categories,
        string[]? levels,
        string[]? languages,
        int? priceFrom,
        int? priceTo,
        Guid? teacherId,
        string? query
    );
    
    Task<IEnumerable<CourseWidgetDTO>> GetCoursesBasedOnQuery(string query);

    Task<CourseDetailsDTO?> GetCourseDetailsAsync(Guid courseId);
    Task<IReadOnlyCollection<CourseCategory>> GetAllDistinctCategoriesAsync();
    Task<IReadOnlyCollection<CourseLevel>> GetAllDistinctLevelsAsync();
    Task<IReadOnlyCollection<CourseLanguage>> GetAllDistinctLanguagesAsync();
    Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityByCourseId(Guid courseId);
    Task<(bool Success, string Message, ProfilePicture? ProfilePicture)> UploadProfilePictureAsync(Guid courseId, Guid userId, IFormFile file);
}