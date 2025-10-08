using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ISpectatorsService
{
    Task<IEnumerable<SpectatorDTO>> GetSpectatedByAsync(Guid userId);
    Task<bool> RemoveSpectatorAsync(Guid spectatorId, Guid spectatedId);
    Task<bool> AddSpectatorAsync(Guid spectatorId, Guid spectatedId);
}