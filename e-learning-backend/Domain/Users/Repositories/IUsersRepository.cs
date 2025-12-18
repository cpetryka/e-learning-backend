using e_learning_backend.Domain.Users;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> ExistsAsync(Guid userId);
    Task<Guid?> GetIdByEmailAsync(string email);
}