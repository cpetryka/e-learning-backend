using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.RegularExpressions;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Services.DTO;
using e_learning_backend.Infrastructure.Security.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace e_learning_tests.Infrastructure.Security.Impl;

[TestClass]
public class SecurityServiceLoginAsyncTests
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

    private static async Task<User> SeedUserAsync(
        ApplicationContext ctx,
        string email,
        string rawPassword,
        string role = "Student",
        string name = "John",
        string surname = "Doe",
        string phone = "+48123456789")
    {
        var user = new User(
            name: name,
            surname: surname,
            email: email,
            hashedPassword: BCrypt.Net.BCrypt.HashPassword(rawPassword),
            phone: phone,
            Role.FromString(role)
        );

        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();
        return user;
    }

    private static string? GetNameClaim(JwtSecurityToken jwt)
    {
        return jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName)?.Value;
    }

    private static string? GetUserIdClaim(JwtSecurityToken jwt)
    {
        return jwt.Claims.FirstOrDefault(c =>
                c.Type == JwtRegisteredClaimNames.Sub ||
                c.Type == "sub" ||
                c.Type == "nameid")
            ?.Value;
    }

    [TestMethod]
    public async Task LoginAsync_ShouldFail_WhenUserDoesNotExist()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var dto = new LoginUserDto
        {
            Email = "not.exists@example.com",
            Password = "SomePassword1!"
        };

        // Act
        var result = await service.LoginAsync(dto);

        // Assert
        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Errors);
        CollectionAssert.Contains(result.Errors, "Invalid e-mail or password");
        Assert.IsNull(result.AccessToken);
        Assert.IsNull(result.RefreshToken);
        Assert.IsNull(result.Roles);
    }

    [TestMethod]
    public async Task LoginAsync_ShouldFail_WhenPasswordIsInvalid()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var email = "john@example.com";
        var correctPassword = "Correct#123";
        await SeedUserAsync(ctx, email, correctPassword, role: "Student");

        var dto = new LoginUserDto
        {
            Email = email,
            Password = "WrongPassword!"
        };

        // Act
        var result = await service.LoginAsync(dto);

        // Assert
        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Errors);
        CollectionAssert.Contains(result.Errors, "Invalid e-mail or password");
        Assert.IsNull(result.AccessToken);
        Assert.IsNull(result.RefreshToken);
        Assert.IsNull(result.Roles);
    }

    [TestMethod]
    public async Task LoginAsync_ShouldReturnTokens_SetRefreshToken_AndExposeRoles()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var email = "teacher@example.com";
        var password = "Passw0rd!";
        var role = "Teacher";

        var user = await SeedUserAsync(ctx, email, password, role: role);

        var dto = new LoginUserDto
        {
            Email = email,
            Password = password
        };

        // Act
        var beforeUtc = DateTime.UtcNow;
        var result = await service.LoginAsync(dto);
        var afterUtc = DateTime.UtcNow;

        // Assert: DTO
        Assert.IsTrue(result.Success);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.AccessToken));
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.RefreshToken));
        Assert.AreEqual(user.Id.ToString(), result.UserId);

        // Refresh token format (32 hex chars, guid "N")
        StringAssert.Matches(result.RefreshToken, new Regex("^[0-9a-fA-F]{32}$"));

        // Roles z DTO
        Assert.IsNotNull(result.Roles);
        Assert.IsNotNull(result.Roles.Any(r => r == role));

        // Check that new refresh token and expiry are saved in DB
        var userFromDb = await ctx.Users
            .Include(u => u.Roles)
            .SingleAsync(u => u.Email == email);

        Assert.AreEqual(result.RefreshToken, userFromDb.RefreshToken);
        Assert.IsNotNull(userFromDb.RefreshTokenExpiryTime);
        var minRt = beforeUtc.AddHours(23);
        var maxRt = afterUtc.AddHours(25);
        Assert.IsTrue(userFromDb.RefreshTokenExpiryTime >= minRt &&
                      userFromDb.RefreshTokenExpiryTime <= maxRt,
            $"RefreshTokenExpiryTime {userFromDb.RefreshTokenExpiryTime:O} should be approximately 24h from now.");

        // Parse JWT
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(result.AccessToken);

        // Format JWT
        StringAssert.Matches(result.AccessToken,
            new Regex(@"^[A-Za-z0-9\-_]+\.[A-Za-z0-9\-_]+\.[A-Za-z0-9\-_]+$"));

        // Claim: e-mail
        var nameValue = GetNameClaim(jwt);
        Assert.IsNotNull(nameValue, "No email claim in the token.");
        Assert.AreEqual(email, nameValue);

        // Claim: user id
        var idValue = GetUserIdClaim(jwt);
        Assert.IsNotNull(idValue, "No id claim in the token.");
        Assert.AreEqual(user.Id.ToString(), idValue);

        // Claim: roles
        var rolesClaim = jwt.Claims.FirstOrDefault(c => c.Type == "roles");
        Assert.IsNotNull(rolesClaim, "No 'roles' claim in the token.");
        Assert.AreEqual(role.ToLower(), rolesClaim.Value);
    }

    [TestMethod]
    public async Task LoginAsync_ShouldRotateRefreshToken_OnSubsequentLogins()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var email = "student@example.com";
        var password = "Passw0rd!";
        await SeedUserAsync(ctx, email, password, role: "Student");

        var dto = new LoginUserDto { Email = email, Password = password };

        // Act
        var result1 = await service.LoginAsync(dto);
        var result2 = await service.LoginAsync(dto);

        // Assert
        Assert.IsTrue(result1.Success);
        Assert.IsTrue(result2.Success);
        Assert.AreNotEqual(result1.RefreshToken, result2.RefreshToken,
            "Refresh token should rotate with each login.");

        // In DB should be the second (last) refresh token
        var userFromDb = await ctx.Users.SingleAsync(u => u.Email == email);
        Assert.AreEqual(result2.RefreshToken, userFromDb.RefreshToken);
    }
}