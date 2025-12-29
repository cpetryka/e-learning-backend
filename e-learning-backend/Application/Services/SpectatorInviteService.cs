using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl.Interfaces;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;



/// <summary>
/// Application service responsible for managing the lifecycle of spectator invitations,
/// including creation, retrieval, validation, and acceptance.
/// </summary>
/// <remarks>
/// This service acts as a coordination layer between repositories and domain entities,
/// enforcing business rules related to spectator invites.
/// </remarks>
public class SpectatorInviteService : ISpectatorInviteService
{
    private readonly ISpectatorInviteRepository _repository;
    private readonly IUsersRepository _users;

    public SpectatorInviteService(ISpectatorInviteRepository repository, IUsersRepository users)
    {
        _repository = repository;
        _users = users;
    }

    
    /// <summary>
    /// Creates a new spectator invitation for a given pair of users.
    /// </summary>
    /// <param name="spectatedId">The ID of the user being spectated (inviter).</param>
    /// <param name="spectatorId">The ID of the invited spectator.</param>
    /// <param name="token">A secure, unique token used to identify the invitation.</param>
    /// <param name="expiresAtUtc">The UTC expiration date and time of the invitation.</param>
    /// <returns>The unique identifier (<see cref="Guid"/>) of the newly created invitation.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when:
    /// <list type="bullet">
    /// <item>A pending invite already exists for the same pair of users.</item>
    /// <item>Either the spectated or spectator user cannot be found.</item>
    /// </list>
    /// </exception>
    public async Task<Guid> CreateAsync(
        Guid spectatedId,
        Guid spectatorId,
        string token,
        DateTime expiresAtUtc)
    {
        
        if (await _repository.ExistsPendingAsync(spectatedId, spectatorId))
            throw new InvalidOperationException("A pending invite already exists for this pair.");
        
        var spectated = await _users.GetByIdAsync(spectatedId)
                        ?? throw new InvalidOperationException("Spectated user not found.");
        var spectator = await _users.GetByIdAsync(spectatorId)
                        ?? throw new InvalidOperationException("Spectator user not found.");

        
        var invite = new SpectatorInvite(
            spectated: spectated,
            spectator: spectator,
            token: token,
            expiresAtUtc: expiresAtUtc
        );

        
        await _repository.AddAsync(invite);
        return invite.Id;
    }
    
    /// <summary>
    /// Retrieves a spectator invitation by its unique token.
    /// </summary>
    /// <param name="token">The invitation token.</param>
    /// <returns>
    /// The corresponding <see cref="SpectatorInvite"/> if found; otherwise, <c>null</c>.
    /// </returns>
    public Task<SpectatorInvite?> GetByTokenAsync(string token) => _repository.GetByTokenAsync(token);

    
    /// <summary>
    /// Checks whether the specified user is the invited spectator for the given invitation.
    /// </summary>
    /// <param name="invite">The invitation to check.</param>
    /// <param name="currentUserId">The ID of the current user.</param>
    /// <returns>
    /// <c>true</c> if the current user is the invited spectator; otherwise, <c>false</c>.
    /// </returns>
    public Task<bool> IsCurrentUserTheSpectatorAsync(SpectatorInvite invite, Guid currentUserId)
    {
        var ok = invite is not null
                 && currentUserId != Guid.Empty
                 && invite.Spectator is not null
                 && invite.Spectator.Id == currentUserId;

        return Task.FromResult(ok);
    }

    
    /// <summary>
    /// Accepts a spectator invitation for the specified user.
    /// </summary>
    /// <param name="invite">The invitation to be accepted.</param>
    /// <param name="currentUserId">The ID of the currently authenticated user.</param>
    /// <param name="ct">An optional cancellation token.</param>
    /// <returns>
    /// <c>true</c> if the invitation was successfully accepted or was already accepted;
    /// otherwise, <c>false</c> (e.g., expired, invalid, or mismatched user).
    /// </returns>
    /// <remarks>
    /// This method validates:
    /// <list type="bullet">
    /// <item>The invitation has not expired.</item>
    /// <item>The invitation has not been accepted before.</item>
    /// <item>The current user is the one invited.</item>
    /// </list>
    /// When accepted, a spectatorship relation between the users is created if necessary.
    /// </remarks>
    public async Task<bool> AcceptAsync(SpectatorInvite invite, Guid currentUserId, CancellationToken ct = default)
    {
        if (invite is null || currentUserId == Guid.Empty) return false;
        if (invite.AcceptedAtUtc != null) return true;
        if (invite.ExpiresAtUtc <= DateTime.UtcNow) return false;
        if (invite.Spectator is null || invite.Spectated is null) return false;
        if (invite.Spectator.Id != currentUserId) return false;

        var linked = await _repository.EnsureSpectatorshipAsync(invite.Spectated, invite.Spectator, ct);
        if (!linked) return false;

        await _repository.MarkInviteAcceptedAsync(invite, ct);
        return true;
    }
}