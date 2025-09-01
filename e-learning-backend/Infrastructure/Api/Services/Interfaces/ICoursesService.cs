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
        Guid? teacherId
    );

    Task<CourseDetailsDTO?> GetCourseDetailsAsync(Guid courseId);
}