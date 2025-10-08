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
    /// This method loads the <c>SpectatedBy</c> navigation property of the <see cref="User"/> entity
    /// and projects each related spectator into a lightweight data transfer object (<see cref="SpectatorDTO"/>).
    /// If the user does not exist or has no spectators, an empty collection is returned.
    /// The results are ordered alphabetically by spectator email.
    /// </remarks>
    public async Task<IEnumerable<SpectatorDTO>> GetSpectatedByAsync(Guid userId)
    {
        var user = await _context.Users
            .AsNoTracking()
            .Include(u => u.SpectatedBy)
            .SingleOrDefaultAsync(u => u.Id == userId);

        if (user is null || user.SpectatedBy.Count == 0)
            return Enumerable.Empty<SpectatorDTO>();

        return user.SpectatedBy
            .Select(s => new SpectatorDTO
            {
                Id = s.Id,
                Email = s.Email,
                Status = null
            })
            .OrderBy(x => x.Email)
            .ToList();
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
    /// This method ensures that the spectatorship relationship between the two users
    /// is removed consistently on both sides
    /// The domain method <see cref="User.RemoveSpectator(User)"/> is invoked on the spectated user
    /// to enforce aggregate invariants and maintain bidirectional consistency.
    /// </remarks>
    public async Task<bool> RemoveSpectatorAsync(Guid spectatorId, Guid spectatedId)
    {
        
        if (spectatorId == Guid.Empty || spectatedId == Guid.Empty)
            return false;
        
        var spectator = await _context.Users
            .Include(u => u.Spectates)
            .SingleOrDefaultAsync(u => u.Id == spectatorId);

        if (spectator is null)
            return false;
        
        var spectated = await _context.Users
            .Include(u => u.SpectatedBy)
            .SingleOrDefaultAsync(u => u.Id == spectatedId);

        if (spectated is null)
            return false;

        try
        {
            spectated.RemoveSpectator(spectator);
        }
        catch (InvalidOperationException)
        {
            return false;
        }

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
    ///   <item><description>Prevents duplicate relationships.</description></item>
    ///   <item><description>Ensures that only users with the <c>Student</c> role can be spectated.</description></item>
    /// </list>
    /// <para>
    /// The relationship is established using the domain method
    /// <see cref="User.AddSpectator(User)"/>, which maintains bidirectional consistency
    /// between the <c>SpectatedBy</c> and <c>Spectates</c> collections.
    /// </para>
    /// <para>
    /// If the operation violates any business rules (e.g., missing role, invalid state),
    /// an <see cref="InvalidOperationException"/> is caught and the method returns <c>false</c>.
    /// </para>
    /// </remarks>
    public async Task<bool> AddSpectatorAsync(Guid spectatorId, Guid spectatedId)
    {
        
        if (spectatorId == Guid.Empty || spectatedId == Guid.Empty)
            return false;
        
        var spectated = await _context.Users
            .Include(u => u.SpectatedBy)
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == spectatedId);
        if (spectated is null) return false;

        var spectator = await _context.Users
            .SingleOrDefaultAsync(u => u.Id == spectatorId);
        if (spectator is null) return false;

        if (spectated.SpectatedBy.Contains(spectator))
            return false;

        try
        {
            spectated.AddSpectator(spectator);
        }
        catch (InvalidOperationException)
        {
            return false;
        }

        await _context.SaveChangesAsync();
        return true;
    }

}