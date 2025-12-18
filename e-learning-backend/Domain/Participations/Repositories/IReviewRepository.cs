using e_learning_backend.Domain.Participations;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IReviewRepository
{
    Task<Review?> GetByIdAsync(Guid id);
    Task<IEnumerable<Review>> GetAllAsync();
    Task AddAsync(Review review);
    Task UpdateAsync(Review review);
    Task DeleteAsync(Guid id);
    Task<Review?> GetByParticipationIdAsync(Guid userId, Guid courseId);
}