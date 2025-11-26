using System.IdentityModel.Tokens.Jwt;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Persistence.Services.DTO;
using e_learning_backend.Infrastructure.Security.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace e_learning_tests.Infrastructure.Security.Impl;

[TestClass]
public class SecurityServiceRegisterAsyncTest
{
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
            .Options;

        return new ApplicationContext(options);
    }

    private static SecurityService BuildService(ApplicationContext ctx)
        => new SecurityService(ctx, BuildConfiguration());

    private static RegisterUserDto CreateRegisterDto(string email = "john.doe@example.com",
        string role = "Student")
    {
        return new RegisterUserDto
        {
            Email = email,
            Password = "Passw0rd!",
            Name = "John",
            Surname = "Doe",
            Phone = "+48123456789",
            AboutMe = "About me",
            AccountType = role
        };
    }

    [TestMethod]
    public async Task RegisterAsync_ShouldReturnError_WhenEmailAlreadyExists()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        ctx.Users.Add(new User("Jane", "Doe", "jane@example.com",
            BCrypt.Net.BCrypt.HashPassword("Secret123!"), "+48111222333",
            Role.FromString("Student")));
        await ctx.SaveChangesAsync();

        var dto = CreateRegisterDto(email: "jane@example.com");

        // Act
        var result = await service.RegisterAsync(dto);

        // Assert
        Assert.IsFalse(result.Success);
        Assert.IsTrue(result.Errors.Contains("User already exists"));
        Assert.IsNull(result.AccessToken);
    }

    [TestMethod]
    public async Task RegisterAsync_ShouldCreateUser_AndReturnTokens()
    {
        // Arrange
        var dbName = Guid.NewGuid().ToString("N");
        await using var ctx = BuildContext(dbName);
        var service = BuildService(ctx);

        var dto = CreateRegisterDto();

        // Act
        var result = await service.RegisterAsync(dto);

        // Assert
        Assert.IsTrue(result.Success);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.AccessToken));
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.RefreshToken));

        var user = await ctx.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
        Assert.IsNotNull(user);
        Assert.IsTrue(BCrypt.Net.BCrypt.Verify(dto.Password, user!.HashedPassword));

        // JWT Check
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(result.AccessToken);
        var nameClaim =
            jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName);
        Assert.IsNotNull(nameClaim);
        Assert.AreEqual(dto.Email, nameClaim!.Value);
    }
}