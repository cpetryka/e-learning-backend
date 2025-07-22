using e_learning_backend.Domain.Classes.ValueObjects;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public interface IClassStatusRepository
{
    Task<ClassStatus?> GetByIdAsync(Guid id);
    Task<IEnumerable<ClassStatus>> GetAllAsync();
    Task AddAsync(ClassStatus status);
    Task UpdateAsync(ClassStatus status);
    Task DeleteAsync(Guid id);
}