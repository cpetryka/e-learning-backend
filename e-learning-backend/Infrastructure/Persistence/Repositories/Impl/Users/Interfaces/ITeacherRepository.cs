using e_learning_backend.Domain.Users;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ITeacherRepository
{
    Task<User?> GetTeacherWithDetailsAsync(Guid teacherId);
}