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
            return BadRequest(authorizationResult.Errors);

        SetTokenCookies(authorizationResult.AccessToken!, authorizationResult.RefreshToken!);

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            RefreshToken = authorizationResult.RefreshToken,
            Roles = authorizationResult.Roles
        });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        var authorizationResult = await _securityService.LoginAsync(loginUserDto);

        if (!authorizationResult.Success)
            return BadRequest(authorizationResult.Errors);

        // ustaw tokeny w cookies
        SetTokenCookies(authorizationResult.AccessToken!, authorizationResult.RefreshToken!);

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            RefreshToken = authorizationResult.RefreshToken,
            Roles = authorizationResult.Roles
        });
    }


    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        if (!Request.Cookies.TryGetValue("RefreshToken", out var refreshToken))
            return BadRequest(new[] { "Refresh token not found" });

        var authorizationResult = await _securityService.RefreshTokenAsync(refreshToken);

        if (!authorizationResult.Success)
            return BadRequest(authorizationResult.Errors);

        SetTokenCookies(authorizationResult.AccessToken!, authorizationResult.RefreshToken!);

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            RefreshToken = authorizationResult.RefreshToken,
            Roles = authorizationResult.Roles
        });
    }

    
    
    
    private void SetTokenCookies(string accessToken, string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false, // zmienić jeśli będziemy chcieli otwierać na świat wtedy będzie szyfrowane
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(15)
        };

        Response.Cookies.Append("AccessToken", accessToken, cookieOptions);

        Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddHours(1)
        });
    }

    
}