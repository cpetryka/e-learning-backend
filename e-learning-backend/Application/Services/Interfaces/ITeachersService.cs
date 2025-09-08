using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ITeacherService
{
    Task<TeacherDTO?> GetTeacherAsync(Guid teacherId);
    Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviewsAsync(Guid teacherId);
    Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId);
}