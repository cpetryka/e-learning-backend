using e_learning_backend.Domain.Users;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl.Interfaces;

public interface ISpectatorInviteRepository
{
    Task<bool> ExistsPendingAsync(Guid spectatedId, Guid spectatorId);
    
    Task<SpectatorInvite?> GetByTokenAsync(string token);
    Task AddAsync(SpectatorInvite invite);
    Task<bool> EnsureSpectatorshipAsync(User student, User spectator, CancellationToken ct = default);
    Task MarkInviteAcceptedAsync(SpectatorInvite invite, CancellationToken ct = default);
}