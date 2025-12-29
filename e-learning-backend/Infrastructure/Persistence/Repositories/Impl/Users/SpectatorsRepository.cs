using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl.Users;

public class SpectatorsRepository : ISpectatorsRepository
{
    private readonly ApplicationContext _context;

    public SpectatorsRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all users who are currently spectating (observing) the specified user.
    /// </summary>
    /// <param name="userId">
    /// The unique identifier of the user being spectated (the user whose spectators are requested).
    /// </param>
    /// <returns>
    /// A collection of <see cref="SpectatorDTO"/> objects representing the spectators
    /// of the specified user. Each item contains the spectator's ID, email address,
    /// and an optional <c>Status</c> field (currently <c>null</c>).
    /// </returns>
    /// <remarks>
    /// This method queries accepted <see cref="SpectatorInvite"/> entities where the spectated user matches
    /// the specified user ID and projects each related spectator into a lightweight data transfer object (<see cref="SpectatorDTO"/>).
    /// If the user does not exist or has no accepted spectators, an empty collection is returned.
    /// The results are ordered alphabetically by spectator email.
    /// </remarks>
    public async Task<IEnumerable<SpectatorDTO>> GetSpectatedByAsync(Guid userId)
    {
        var spectators = await _context.SpectatorInvites
            .AsNoTracking()
            .Include(i => i.Spectator)
            .Where(i => EF.Property<Guid>(i, "SpectatedId") == userId && i.AcceptedAtUtc != null)
            .Select(i => new SpectatorDTO
            {
                Id = i.Spectator.Id,
                Email = i.Spectator.Email,
                Status = null
            })
            .OrderBy(x => x.Email)
            .ToListAsync();

        return spectators;
    }


    /// <summary>
    /// Removes the spectatorship relationship between a specific spectator and a spectated user,
    /// identified by their unique identifiers.
    /// </summary>
    /// <param name="spectatorId">
    /// The unique identifier of the spectator (the user who observes another user).
    /// </param>
    /// <param name="spectatedId">
    /// The unique identifier of the spectated user (the user being observed).
    /// </param>
    /// <returns>
    /// <c>true</c> if both users exist and the spectatorship relationship was successfully removed;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method removes the accepted <see cref="SpectatorInvite"/> entity that represents the spectatorship
    /// relationship between the two users. The invite is deleted from the database.
    /// </remarks>
    public async Task<bool> RemoveSpectatorAsync(Guid spectatorId, Guid spectatedId)
    {
        if (spectatorId == Guid.Empty || spectatedId == Guid.Empty)
            return false;

        var invite = await _context.SpectatorInvites
            .Where(i => EF.Property<Guid>(i, "SpectatedId") == spectatedId &&
                        EF.Property<Guid>(i, "SpectatorId") == spectatorId &&
                        i.AcceptedAtUtc != null)
            .FirstOrDefaultAsync();

        if (invite is null)
            return false;

        _context.SpectatorInvites.Remove(invite);
        await _context.SaveChangesAsync();
        return true;
    }


    /// <summary>
    /// Creates a new spectatorship relationship between two existing users,
    /// where the specified <paramref name="spectatorId"/> user becomes a spectator
    /// of the <paramref name="spectatedId"/> user.
    /// </summary>
    /// <param name="spectatorId">
    /// The unique identifier of the user who will become the spectator (observer).
    /// </param>
    /// <param name="spectatedId">
    /// The unique identifier of the user who is being spectated (the student).
    /// </param>
    /// <returns>
    /// A task that resolves to <c>true</c> if the spectatorship was successfully created;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The method performs several validation and domain consistency checks before
    /// creating the spectatorship:
    /// </para>
    /// <list type="number">
    ///   <item><description>Ensures both users exist in the database.</description></item>
    ///   <item><description>Prevents duplicate relationships by checking for existing accepted invites.</description></item>
    /// </list>
    /// <para>
    /// The relationship is established by creating a new <see cref="SpectatorInvite"/> entity
    /// that is immediately marked as accepted. This replaces the previous many-to-many relationship.
    /// </para>
    /// </remarks>
    public async Task<bool> AddSpectatorAsync(Guid spectatorId, Guid spectatedId)
    {
        if (spectatorId == Guid.Empty || spectatedId == Guid.Empty)
            return false;

        var spectated = await _context.Users
            .SingleOrDefaultAsync(u => u.Id == spectatedId);
        if (spectated is null) return false;

        var spectator = await _context.Users
            .SingleOrDefaultAsync(u => u.Id == spectatorId);
        if (spectator is null) return false;

        // Check if relationship already exists
        var exists = await _context.SpectatorInvites
            .AnyAsync(i => EF.Property<Guid>(i, "SpectatedId") == spectatedId &&
                          EF.Property<Guid>(i, "SpectatorId") == spectatorId &&
                          i.AcceptedAtUtc != null);
        if (exists)
            return false;

        // Create a new accepted invite to represent the relationship
        var invite = new SpectatorInvite(
            spectated: spectated,
            spectator: spectator,
            token: Guid.NewGuid().ToString(), // Generate a token for consistency
            expiresAtUtc: DateTime.UtcNow.AddYears(100) // Far future expiration
        );
        invite.AcceptInvite(); // Mark as accepted immediately

        _context.SpectatorInvites.Add(invite);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<StudentBriefDTO>> GetSpectatedStudentsAsync(Guid spectatorId)
    {
        return await _context.SpectatorInvites
            .AsNoTracking()
            .Include(i => i.Spectated)
            .Where(i => EF.Property<Guid>(i, "SpectatorId") == spectatorId && i.AcceptedAtUtc != null)
            .Select(i => new StudentBriefDTO
            {
                Id = i.Spectated.Id,
                Name = i.Spectated.Name,
                Surname = i.Spectated.Surname
            })
            .ToListAsync();
    }
}