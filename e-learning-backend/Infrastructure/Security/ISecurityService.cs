using e_learning_backend.Infrastructure.Persistence.Services.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Services;

public interface ISecurityService
{
    Task<AuthorizationResultDto> RegisterAsync(RegisterUserDto registerUserDto);
    Task<AuthorizationResultDto> LoginAsync(LoginUserDto loginUserDto);
    Task<AuthorizationResultDto> RefreshTokenAsync(string refreshToken);
    Task LogoutAsync(Guid userId);
}