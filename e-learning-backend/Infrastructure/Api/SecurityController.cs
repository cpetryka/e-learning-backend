using e_learning_backend.Infrastructure.Persistence.Services;
using e_learning_backend.Infrastructure.Persistence.Services.DTO;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api;

[Route("api/security")]
public class SecurityController : ControllerBase
{
    private ISecurityService _securityService;

    public SecurityController(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        var authorizationResult = await _securityService.RegisterAsync(registerUserDto);

        if (!authorizationResult.Success)
        {
            return BadRequest(authorizationResult.Errors);
        }

        return Ok(authorizationResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        var authorizationResult = await _securityService.LoginAsync(loginUserDto);

        if (!authorizationResult.Success)
        {
            return BadRequest(authorizationResult.Errors);
        }

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            RefreshToken = authorizationResult.RefreshToken
        });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(string refreshToken)
    {
        var authorizationResult = await _securityService.RefreshTokenAsync(refreshToken);

        if (!authorizationResult.Success)
        {
            return BadRequest(authorizationResult.Errors);
        }

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            RefreshToken = authorizationResult.RefreshToken
        });
    }
}