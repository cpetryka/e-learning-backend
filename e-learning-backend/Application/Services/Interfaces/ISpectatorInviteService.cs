namespace e_learning_backend.Infrastructure.Security.Impl.Interfaces;

public interface ISpectatorInviteService
{
    Task<Guid> CreateAsync(Guid spectatedId, Guid spectatorId, string spectatorEmail, string token, DateTime expiresAtUtc);
    Task<SpectatorInvite?> GetByTokenAsync(string token);
    Task<bool> IsCurrentUserTheSpectatorAsync(SpectatorInvite invite, Guid currentUserId);
    Task<bool> AcceptAsync(SpectatorInvite invite, Guid currentUserId, CancellationToken ct = default);
}