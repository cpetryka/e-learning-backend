using e_learning_backend.Domain.Classes;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public interface IClassRepository
{
    Task<Class?> GetByIdAsync(Guid id);
    Task<IEnumerable<Class>> GetAllAsync();
    Task AddAsync(Class cls);
    Task UpdateAsync(Class cls);
    Task DeleteAsync(Guid id);
}