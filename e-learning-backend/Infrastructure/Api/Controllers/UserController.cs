using System.Security.Claims;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("aboutMe")]
    [Authorize]
    public async Task<ActionResult<AboutMeDTO>> GetAboutMe()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return Unauthorized();

        var userId = Guid.Parse(userIdClaim);
        var aboutMe = await _usersService.GetAboutMeAsync(userId);

        if (aboutMe == null) return NotFound();
        return Ok(aboutMe);
    }
}