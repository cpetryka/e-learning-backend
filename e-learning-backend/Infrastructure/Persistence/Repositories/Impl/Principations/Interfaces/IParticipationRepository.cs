using e_learning_backend.Domain.Participations;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface IParticipationRepository
{
    Task<Participation?> GetByIdAsync(Guid userId, Guid courseId);
    Task<IEnumerable<Participation>> GetAllAsync();
    Task AddAsync(Participation participation);
    Task UpdateAsync(Participation participation);
    Task DeleteAsync(Guid userId, Guid courseId);
    Task<IEnumerable<Participation>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<ParticipationBriefDTO>> GetBriefByUserIdAsync(Guid userId);
    Task<IEnumerable<Participation>> GetByCourseIdAsync(Guid courseId);
}