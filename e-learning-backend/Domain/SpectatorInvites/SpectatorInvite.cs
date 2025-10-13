using System.Security.Cryptography;
using e_learning_backend.Domain.Users;
using Microsoft.AspNetCore.WebUtilities;

/// <summary>
/// Represents an invitation allowing a spectator to gain access to observe a specific user (the spectated one)
/// within the e-learning platform. 
/// </summary>
/// <remarks>
/// This is a domain entity managed by Entity Framework Core. 
/// Each invitation is secured with a unique token, has a defined expiration date, 
/// and can only be accepted once by the invited spectator.
/// </remarks>

public class SpectatorInvite
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public User Spectated { get; private set; } = default!;
    public User Spectator { get; private set; } = default!;

    public string SpectatorEmail { get; private set; } = default!;
    public string Token { get; private set; } = default!;
    public DateTime ExpiresAtUtc { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public bool Accepted { get; private set; } = false;
    public DateTime? AcceptedAtUtc { get; private set; }
    
    private SpectatorInvite() { } 
    
    /// <summary>
    /// Creates a new spectator invitation for the specified users and email address.
    /// </summary>
    /// <param name="spectated">The user being spectated (inviter).</param>
    /// <param name="spectator">The invited spectator user.</param>
    /// <param name="email">The email address of the spectator.</param>
    /// <param name="token">A secure, unique token associated with this invitation.</param>
    /// <param name="expiresAtUtc">The UTC expiration date and time of the invitation.</param>
    /// <exception cref="ArgumentNullException">Thrown when either user reference is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="email"/> or <paramref name="token"/> is null or empty.</exception>
    public SpectatorInvite(User spectated, User spectator, string email, string token, DateTime expiresAtUtc)
    {
        Spectated = spectated ?? throw new ArgumentNullException(nameof(spectated));
        Spectator = spectator ?? throw new ArgumentNullException(nameof(spectator));
        SpectatorEmail = string.IsNullOrWhiteSpace(email) ? throw new ArgumentException("Email required", nameof(email)) : email.Trim();
        Token = string.IsNullOrWhiteSpace(token) ? throw new ArgumentException("Token required", nameof(token)) : token;
        ExpiresAtUtc = expiresAtUtc;
    }
    
    
    /// <summary>
    /// Marks the invitation as accepted and records the acceptance timestamp.
    /// </summary>
    /// <remarks>
    /// If the invitation has already been accepted, the method does nothing.
    /// </remarks>
    public void AcceptInvite()
    {
        if (Accepted) return;
        Accepted = true;
        AcceptedAtUtc = DateTime.UtcNow;
    }
    
}
