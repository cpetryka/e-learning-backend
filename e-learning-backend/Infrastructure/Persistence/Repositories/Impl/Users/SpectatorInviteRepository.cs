using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl.Interfaces;
using Npgsql;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

using Microsoft.EntityFrameworkCore;


/// <summary>
/// Repository responsible for reading and persisting <see cref="SpectatorInvite"/> entities
/// and for establishing spectatorship relations between users.
/// </summary>

public class SpectatorInviteRepository : ISpectatorInviteRepository
{
    private readonly ApplicationContext _context;

    public SpectatorInviteRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Checks whether there exists a non-accepted, non-expired invitation
    /// for the given spectated/spectator pair.
    /// </summary>
    /// <param name="spectatedId">The ID of the user being spectated.</param>
    /// <param name="spectatorId">The ID of the invited spectator.</param>
    /// <returns>
    /// <c>true</c> if a pending (not accepted and not expired) invite exists; otherwise <c>false</c>.
    /// </returns>
    /// 
    public async Task<bool> ExistsPendingAsync(Guid spectatedId, Guid spectatorId)
    {
        return await _context.SpectatorInvites
            .AsNoTracking()
            .AnyAsync(i =>
                EF.Property<Guid>(i, "SpectatedId") == spectatedId &&
                EF.Property<Guid>(i, "SpectatorId") == spectatorId &&
                !i.Accepted &&
                i.ExpiresAtUtc > DateTime.UtcNow);
    }

    
    /// <summary>
    /// Adds a new <see cref="SpectatorInvite"/> and persists it to the database.
    /// </summary>
    /// <param name="invite">The invitation entity to add.</param>
    public async Task AddAsync(SpectatorInvite invite)
    {
        _context.SpectatorInvites.Add(invite);
        await _context.SaveChangesAsync();
    }
   
    /// <summary>
    /// Retrieves a single <see cref="SpectatorInvite"/> by its token, including navigations to users.
    /// </summary>
    /// <param name="token">The unique token associated with the invitation.</param>
    /// <returns>
    /// The matching <see cref="SpectatorInvite"/> or <c>null</c> if no match was found
    /// or the token is null/whitespace.
    /// </returns>
    public async Task<SpectatorInvite?> GetByTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return null;
        var spectatorInvite = await _context.SpectatorInvites
            .Include(i => i.Spectated)
            .Include(i => i.Spectator)
            .SingleOrDefaultAsync(i => i.Token == token);
        Console.WriteLine(spectatorInvite);
        return spectatorInvite;
    }
    
    
    /// <summary>
    /// Ensures that the given <paramref name="spectator"/> is added as a spectator of <paramref name="student"/>.
    /// If the relation already exists, the method is idempotent and returns <c>true</c>.
    /// </summary>
    /// <param name="student">The user being spectated.</param>
    /// <param name="spectator">The spectator user.</param>
    /// <param name="ct">A cancellation token.</param>
    /// <returns>
    /// <c>true</c> if the relation exists or was successfully created; otherwise <c>false</c> if inputs are invalid.
    /// </returns>
    /// <remarks>
    /// Performs an existence check by looking for an accepted <see cref="SpectatorInvite"/>.
    /// If no accepted invite exists, creates a new invite and marks it as accepted immediately.
    /// Uses a transaction with double-check to avoid race conditions.
    /// </remarks>
    public async Task<bool> EnsureSpectatorshipAsync(User student, User spectator, CancellationToken ct = default)
    {
        if (student is null || spectator is null) return false;

        // Fast path: check without locking/trx
        var exists = await _context.SpectatorInvites
            .AnyAsync(i => EF.Property<Guid>(i, "SpectatedId") == student.Id &&
                          EF.Property<Guid>(i, "SpectatorId") == spectator.Id &&
                          i.Accepted, ct);

        if (exists)
            return true;

        // Transaction with double-check to avoid race conditions.
        await using var tx = await _context.Database.BeginTransactionAsync(ct);

        // Double-check inside the transaction
        var stillExists = await _context.SpectatorInvites
            .AnyAsync(i => EF.Property<Guid>(i, "SpectatedId") == student.Id &&
                          EF.Property<Guid>(i, "SpectatorId") == spectator.Id &&
                          i.Accepted, ct);

        if (!stillExists)
        {
            // Check if there's a pending invite that we can accept
            var pendingInvite = await _context.SpectatorInvites
                .Where(i => EF.Property<Guid>(i, "SpectatedId") == student.Id &&
                           EF.Property<Guid>(i, "SpectatorId") == spectator.Id &&
                           !i.Accepted)
                .FirstOrDefaultAsync(ct);

            if (pendingInvite != null)
            {
                // Accept the existing invite
                pendingInvite.AcceptInvite();
            }
            else
            {
                // Create a new invite and mark it as accepted immediately
                var newInvite = new SpectatorInvite(
                    spectated: student,
                    spectator: spectator,
                    email: spectator.Email,
                    token: Guid.NewGuid().ToString(),
                    expiresAtUtc: DateTime.UtcNow.AddYears(100) // Far future expiration
                );
                newInvite.AcceptInvite();
                _context.SpectatorInvites.Add(newInvite);
            }
        }

        await _context.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);
        return true;
    }
    
    
    /// <summary>
    /// Marks the invitation as accepted and persists the change.
    /// </summary>
    /// <param name="invite">The invitation to mark as accepted.</param>
    /// <param name="ct">A cancellation token.</param>
    public async Task MarkInviteAcceptedAsync(SpectatorInvite invite, CancellationToken ct = default)
    {
        invite.AcceptInvite();
        await _context.SaveChangesAsync(ct);
    }
    
}

