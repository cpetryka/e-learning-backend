using System.Security.Claims;
using e_learning_backend.Infrastructure.Persistence.Services;
using e_learning_backend.Infrastructure.Persistence.Services.DTO;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api;

[ApiController]
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

        SetTokenCookies(authorizationResult.RefreshToken!);

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            Roles = authorizationResult.Roles
        });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        var authorizationResult = await _securityService.LoginAsync(loginUserDto);

        if (!authorizationResult.Success)
            return BadRequest(authorizationResult.Errors);


        SetTokenCookies(authorizationResult.RefreshToken!);

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            Roles = authorizationResult.Roles
        });
    }

    /*[HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        if (!Request.Cookies.TryGetValue("RefreshToken", out var refreshToken))
            return BadRequest(new[] { "No refresh token found" });


        var user = await _securityService.RefreshTokenAsync(refreshToken);
        if (!user.Success)
        {
            Response.Cookies.Delete("RefreshToken");
            return Ok(new { Message = "Logged out" });
        }


        var userId = Guid.Parse(user.UserId);
        await _securityService.LogoutAsync(userId);

        // usuń cookie z przeglądarki
        Response.Cookies.Delete("RefreshToken");

        return Ok(new { Message = "Logged out" });
    }*/

    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // 1) Spróbuj wziąć userId z AT (jeśli endpoint wywoływany z autoryzacją)
        var userIdStr = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(userIdStr, out var userId))
        {
            await _securityService.LogoutAsync(userId); // czyści RT w DB
        }
        else if (Request.Cookies.TryGetValue("RefreshToken", out var rt) && !string.IsNullOrWhiteSpace(rt))
        {
            // 2) Fallback: usuń po RT (bez rotacji) – dodaj tę metodę w serwisie
            await _securityService.LogoutByRefreshTokenAsync(rt);
        }

        // Usuń cookie w przeglądarce
        Response.Cookies.Delete("RefreshToken", new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Lax,
            Path = "/"
        });

        return Ok(new { Message = "Logged out" });
    }


    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        if (!Request.Cookies.TryGetValue("RefreshToken", out var refreshToken))
            return BadRequest(new[] { "Refresh token not found" });

        var authorizationResult = await _securityService.RefreshTokenAsync(refreshToken);

        if (!authorizationResult.Success)
            return BadRequest(authorizationResult.Errors);

        SetTokenCookies(authorizationResult.RefreshToken!);

        return Ok(new
        {
            AccessToken = authorizationResult.AccessToken,
            Roles = authorizationResult.Roles
        });
    }


    private void SetTokenCookies(string refreshToken)
    {
        Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Lax,
            Expires = DateTime.UtcNow.AddHours(24)
        });
    }
}