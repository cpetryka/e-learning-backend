using e_learning_backend.Domain.ExercisesAndMaterials;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public interface ILinkResourcesRepository
{
    Task<LinkResource?> GetByIdAsync(Guid id);
    Task AddAsync(LinkResource cls);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(LinkResource cls);
}