using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Services;
using e_learning_backend.Infrastructure.Persistence.Services.DTO;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace e_learning_backend.Infrastructure.Security.Impl;

public class SecurityService : ISecurityService
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _configuration;

    public SecurityService(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<AuthorizationResultDto> RegisterAsync(RegisterUserDto dto)
    {
        // Try to load an existing user with roles
        var existingUser = await _context.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Email == dto.Email);

        var requestedRoleName = dto.AccountType.Trim();
        var requestedRoleNameNormalized = requestedRoleName.ToLowerInvariant();

        if (existingUser != null)
        {
            // If user already has the role
            if (existingUser.Roles.Any(r =>
                    r.RoleName.ToLowerInvariant() == requestedRoleNameNormalized))
            {
                return new AuthorizationResultDto
                {
                    Success = false,
                    Errors = new[] { "User already exists" }
                };
            }

            // Check the provided password
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, existingUser.HashedPassword))
            {
                return new AuthorizationResultDto
                {
                    Success = false,
                    Errors = new[] { "Invalid password for existing user" }
                };
            }

            // Add the new role to the existing user
            existingUser.AddRole(Role.FromString(requestedRoleName));

            // Generate tokens for the existing user
            var accessTokenForExisting = GenerateAccessToken(existingUser);
            var refreshTokenForExisting = GenerateRefreshToken();

            existingUser.RefreshToken = refreshTokenForExisting;
            existingUser.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(24);

            await _context.SaveChangesAsync();

            return new AuthorizationResultDto
            {
                UserId = existingUser.Id.ToString(),
                Success = true,
                AccessToken = accessTokenForExisting,
                RefreshToken = refreshTokenForExisting,
                Roles = existingUser.Roles.Select(r => r.RoleName).ToList()
            };
        }

        // create domain user
        var domainUser = new User(
            name: dto.Name,
            surname: dto.Surname,
            email: dto.Email,
            hashedPassword: BCrypt.Net.BCrypt.HashPassword(dto.Password),
            phone: dto.Phone,
            initialRole: Role.FromString(dto.AccountType.Trim()),
            aboutMe: dto.AboutMe
        );

        // generate tokens
        var accessToken = GenerateAccessToken(domainUser);
        var refreshToken = GenerateRefreshToken();

        // persist new user
        domainUser.RefreshToken = refreshToken;
        domainUser.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(24);

        _context.Users.Add(domainUser);
        await _context.SaveChangesAsync();

        return new AuthorizationResultDto
        {
            UserId = domainUser.Id.ToString(),
            Success = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthorizationResultDto> LoginAsync(LoginUserDto dto)
    {
        var user = await _context.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.HashedPassword))
        {
            return new AuthorizationResultDto
            {
                Success = false,
                Errors = new[] { "Invalid e-mail or password" }
            };
        }

        var accessToken = GenerateAccessToken(user);
        var refreshToken = GenerateRefreshToken();
        var roles = user.Roles.Select(r => r.RoleName).ToList();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(24);
        await _context.SaveChangesAsync();

        return new AuthorizationResultDto
        {
            UserId = user.Id.ToString(),
            Success = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Roles = roles
        };
    }

    public async Task<AuthorizationResultDto> RefreshTokenAsync(string refreshToken)
    {
        var user = await _context.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);

        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return new AuthorizationResultDto
            {
                Success = false,
                Errors = new[] { "Invalid or expired refresh token" }
            };
        }

        var newAccessToken = GenerateAccessToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(24);
        await _context.SaveChangesAsync();

        return new AuthorizationResultDto
        {
            UserId = user.Id.ToString(),
            Success = true,
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            Roles = user.Roles.Select(r => r.RoleName).ToList()
        };
    }

    public async Task LogoutByRefreshTokenAsync(string refreshToken)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null) return;

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = null;
        await _context.SaveChangesAsync();
    }

    // --------------------------------------------------------------------------------------------------------

    private string GenerateAccessToken(e_learning_backend.Domain.Users.User user)
    {
        var keyBytes = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        /*foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
        }*/

        var roleNames = user.Roles.Select(r => r.RoleName).ToList();
        var rolesJson = JsonSerializer.Serialize(roleNames);

        claims.Add(new Claim("roles", rolesJson, JsonClaimValueTypes.JsonArray));


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    public async Task LogoutAsync(Guid userId)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null) return;

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = null;
        await _context.SaveChangesAsync();
    }

    private string GenerateRefreshToken()
        => Guid.NewGuid().ToString("N");

    // --------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Generates a cryptographically secure, URL-safe token for spectator invitations.
    /// </summary>
    /// <param name="bytes">
    /// The number of random bytes to use when generating the token.  
    /// Defaults to <c>32</c>, which provides strong entropy suitable for security-sensitive operations.
    /// </param>
    /// <returns>
    /// A Base64 URL-encoded string representing the secure random token, safe to use in URLs or query parameters.
    /// </returns>
    public static string CreateSpectatorInviteSecureToken(int bytes = 32)
    {
        var data = new byte[bytes];
        RandomNumberGenerator.Fill(data);
        return WebEncoders.Base64UrlEncode(data);
    }
}