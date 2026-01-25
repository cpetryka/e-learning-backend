using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.RegularExpressions;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Security.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace e_learning_tests.Infrastructure.Security.Impl;

[TestClass]
public class SecurityServiceRefreshTokenAsyncTests
{
    public TestContext TestContext { get; set; }
    
    private static IConfiguration BuildConfiguration()
    {
        var settings = new Dictionary<string, string?>
        {
            ["Jwt:Key"] = "THIS_IS_TEST_KEY_32+_CHARS_LONG_1234567890"
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(settings!)
            .Build();
    }

    private static ApplicationContext BuildContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .EnableSensitiveDataLogging()
            .Options;

        return new ApplicationContext(options);
    }

    private static SecurityService BuildService(ApplicationContext ctx)
        => new SecurityService(ctx, BuildConfiguration());

    private static async Task<User> SeedUserWithRefreshAsync(
        ApplicationContext ctx,
        string email,
        string role,
        string refreshToken,
        DateTime? refreshExpiryUtc = null,
        string name = "John",
        string surname = "Doe",
        string phone = "+48123456789",
        string hashedPassword = null)
    {
        var user = new User(
            name: name,
            surname: surname,
            email: email,
            hashedPassword: hashedPassword ?? BCrypt.Net.BCrypt.HashPassword("Passw0rd!"),
            phone: phone,
            Role.FromString(role)
        );

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = refreshExpiryUtc ?? DateTime.UtcNow.AddMinutes(30);

        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();
        return user;
    }

    private static string? GetNameClaim(JwtSecurityToken jwt)
    {
        return jwt.Claims.FirstOrDefault(c =>
                c.Type == JwtRegisteredClaimNames.UniqueName)
            ?.Value;
    }

    private static string? GetUserIdClaim(JwtSecurityToken jwt)
    {
        return jwt.Claims.FirstOrDefault(c =>
                c.Type == JwtRegisteredClaimNames.Sub ||
                c.Type == "sub" ||
                c.Type == "nameid")
            ?.Value;
    }

    private static List<string> ExtractRoles(JwtSecurityToken jwt)
    {
        var roleClaims = jwt.Claims
            .Where(c =>
                c.Type == "roles" || c.Type == "role" ||
                c.Type == System.Security.Claims.ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        if (roleClaims.Count == 0)
        {
            return new List<string>();
        }

        if (roleClaims.Count == 1)
        {
            var single = roleClaims[0]?.Trim();
            if (!string.IsNullOrEmpty(single) && single.StartsWith("[") && single.EndsWith("]"))
            {
                using var doc = JsonDocument.Parse(single);
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    return doc.RootElement.EnumerateArray()
                        .Select(e =>
                            e.ValueKind == JsonValueKind.String ? e.GetString()! : e.ToString())
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .ToList();
                }
            }

            return new List<string> { single! };
        }

        return roleClaims.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
    }

    [TestMethod]
    public async Task RefreshTokenAsync_ShouldFail_WhenTokenNotFound()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        // Act
        var result = await service.RefreshTokenAsync("nonexistent_refresh_token");

        // Assert
        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Errors);
        CollectionAssert.Contains(result.Errors, "Invalid or expired refresh token");
        Assert.IsNull(result.AccessToken);
        Assert.IsNull(result.RefreshToken);
        Assert.IsNull(result.Roles);
    }

    [TestMethod]
    public async Task RefreshTokenAsync_ShouldFail_WhenTokenExpired()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var email = "user@example.com";
        var role = "Student";
        var expiredToken = Guid.NewGuid().ToString("N");
        await SeedUserWithRefreshAsync(
            ctx,
            email: email,
            role: role,
            refreshToken: expiredToken,
            refreshExpiryUtc: DateTime.UtcNow.AddSeconds(-1) // already expired
        );

        // Act
        var result = await service.RefreshTokenAsync(expiredToken);

        // Assert
        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Errors);
        CollectionAssert.Contains(result.Errors, "Invalid or expired refresh token");
        Assert.IsNull(result.AccessToken);
        Assert.IsNull(result.RefreshToken);
    }

    [TestMethod]
    public async Task RefreshTokenAsync_ShouldIssueNewTokens_AndRotateRefreshToken()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var email = "teacher@example.com";
        var role = "Teacher";
        var oldRefreshToken = Guid.NewGuid().ToString("N");
        var user = await SeedUserWithRefreshAsync(
            ctx,
            email: email,
            role: role,
            refreshToken: oldRefreshToken,
            refreshExpiryUtc: DateTime.UtcNow.AddMinutes(5)
        );

        // Act
        var beforeUtc = DateTime.UtcNow;
        var result = await service.RefreshTokenAsync(oldRefreshToken);
        var afterUtc = DateTime.UtcNow;

        // Assert – DTO
        Assert.IsTrue(result.Success);
        Assert.AreEqual(user.Id.ToString(), result.UserId);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.AccessToken));
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.RefreshToken));
        StringAssert.Matches(result.RefreshToken, new Regex("^[0-9a-fA-F]{32}$"));
        Assert.IsNotNull(result.Roles.ToList());
        CollectionAssert.Contains(result.Roles!.ToList(), role.ToLower());

        // DB – rotated refresh token with expiry ~1h from now
        var userFromDb = await ctx.Users.Include(u => u.Roles).SingleAsync(u => u.Email == email);
        Assert.AreEqual(result.RefreshToken, userFromDb.RefreshToken);
        Assert.AreNotEqual(oldRefreshToken, userFromDb.RefreshToken);
        Assert.IsNotNull(userFromDb.RefreshTokenExpiryTime);
        var minRt = beforeUtc.AddHours(23);
        var maxRt = afterUtc.AddHours(25);
        Assert.IsTrue(
            userFromDb.RefreshTokenExpiryTime >= minRt &&
            userFromDb.RefreshTokenExpiryTime <= maxRt,
            $"RefreshTokenExpiryTime {userFromDb.RefreshTokenExpiryTime:O} should be ~24h from now.");

        // JWT
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(result.AccessToken);

        StringAssert.Matches(result.AccessToken,
            new Regex(@"^[A-Za-z0-9\-_]+\.[A-Za-z0-9\-_]+\.[A-Za-z0-9\-_]+$"));

        var nameValue = GetNameClaim(jwt);
        Assert.IsNotNull(nameValue, "No email claim in token.");
        Assert.AreEqual(email, nameValue);

        var idValue = GetUserIdClaim(jwt);
        Assert.IsNotNull(idValue, "No id claim in token.");
        Assert.AreEqual(user.Id.ToString(), idValue);

        var roles = ExtractRoles(jwt);
        Assert.IsTrue(roles.Count >= 1, "No roles claim in token.");
        CollectionAssert.Contains(roles, role.ToLower());
    }

    [TestMethod]
    public async Task RefreshTokenAsync_ShouldAllowChainedRefresh_AndInvalidatePrevious()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var email = "chain@example.com";
        var role = "Student";
        var initialRefresh = Guid.NewGuid().ToString("N");

        await SeedUserWithRefreshAsync(
            ctx,
            email: email,
            role: role,
            refreshToken: initialRefresh,
            refreshExpiryUtc: DateTime.UtcNow.AddMinutes(5)
        );

        // 1) Refresh with initial token
        var r1 = await service.RefreshTokenAsync(initialRefresh);
        Assert.IsTrue(r1.Success);

        // 2) Refresh again with the new token from step 1
        var r2 = await service.RefreshTokenAsync(r1.RefreshToken);
        Assert.IsTrue(r2.Success);
        Assert.AreNotEqual(r1.RefreshToken, r2.RefreshToken);

        // DB should have the latest refresh token
        var userFromDb = await ctx.Users.SingleAsync(u => u.Email == email);
        Assert.AreEqual(r2.RefreshToken, userFromDb.RefreshToken);

        // 3) Try to reuse the token from step 1 - should fail
        var r3 = await service.RefreshTokenAsync(r1.RefreshToken);
        Assert.IsFalse(r3.Success);
        CollectionAssert.Contains(r3.Errors, "Invalid or expired refresh token");
    }
}