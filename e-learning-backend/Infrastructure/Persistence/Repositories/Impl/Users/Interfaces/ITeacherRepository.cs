using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ITeacherRepository
{
    Task<User?> GetTeacherWithDetailsAsync(Guid teacherId);
    Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviews(Guid teacherId);
    Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId);
}