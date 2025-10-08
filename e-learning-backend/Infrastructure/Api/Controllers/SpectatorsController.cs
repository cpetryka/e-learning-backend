using System.Net.Mail;
using System.Security.Claims;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace e_learning_backend.Infrastructure.Api.Controllers;


[ApiController]
[Route("api/[controller]")]

public class SpectatorsController : ControllerBase
{
    private readonly ISpectatorsService _spectatorsService;
    private readonly IUsersService _usersService;

    public SpectatorsController(ISpectatorsService spectatorsService, IUsersService usersService)
    {
        _spectatorsService = spectatorsService;
        _usersService = usersService;
    }
    
    /// <summary>
    /// Retrieves a list of spectators (users who are currently spectating the authenticated student).
    /// </summary>
    /// <remarks>
    /// This endpoint is restricted to users with the <c>student</c> role.  
    /// It extracts the user's identifier (<see cref="ClaimTypes.NameIdentifier"/>) and role information from the JWT token.  
    /// If the role is not <c>student</c>, a <c>403 Forbidden</c> response is returned.  
    /// If no spectators are found, a <c>404 Not Found</c> response is returned.
    /// </remarks>
    /// <returns>
    /// A collection of <see cref="SpectatorDTO"/> objects representing users who spectate the current student.  
    /// Each DTO includes the spectator's <c>Id</c>, <c>Email</c>, and an optional <c>Status</c> field.
    /// </returns>
    /// <response code="200">Successfully retrieved the list of spectators.</response>
    /// <response code="401">Returned when the request is not authenticated or the token is invalid.</response>
    /// <response code="403">Returned when the authenticated user does not have the <c>student</c> role.</response>
    /// <response code="404">Returned when no spectators are found for the current user.</response>
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SpectatorDTO>>> GetMySpectatorsAsync()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var userId))
            return Unauthorized("Invalid or missing user identifier in token.");
    
        var hasStudentRole = User.FindAll(ClaimTypes.Role)
            .Any(r => r.Value.Equals("student", StringComparison.OrdinalIgnoreCase));
        
        Console.WriteLine(hasStudentRole);

        if (!hasStudentRole)
            return Forbid("Access denied: 'student' role is required.");
    
        var spectators = await _spectatorsService.GetSpectatedByAsync(userId);

        if (spectators is null || !spectators.Any())
            return NotFound("No spectators found for the current user.");

        return Ok(spectators);
    }
    
    /// <summary>
    /// Removes a spectatorship relation for the current authenticated user.
    /// </summary>
    /// <param name="request">
    /// The request body containing the <see cref="RemoveSpectatorDTO.SpectatorId"/> to remove.
    /// </param>
    /// <returns>
    /// <c>204 No Content</c> when the spectatorship is removed;<br/>
    /// <c>400 Bad Request</c> when the spectator id is missing or invalid;<br/>
    /// <c>401 Unauthorized</c> when the user id cannot be read from the token;<br/>
    /// <c>404 Not Found</c> when the relationship does not exist.
    /// </returns>
    /// <remarks>
    /// The spectated user's identifier is read from the JWT claim <see cref="ClaimTypes.NameIdentifier"/>.
    /// </remarks>
    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> RemoveMySpectatorAsync([FromBody] RemoveSpectatorDTO request)
    {
        if (request is null || request.SpectatorId == Guid.Empty)
            return BadRequest("A valid SpectatorId must be provided in the request body.");

        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var spectatedId))
            return Unauthorized("Invalid or missing user identifier in token.");

        var removed = await _spectatorsService.RemoveSpectatorAsync(request.SpectatorId, spectatedId);
        if (!removed)
            return NotFound("Spectatorship not found or already removed.");

        return NoContent();
    }

    
    
/// <summary>
    /// Creates a spectatorship for the current authenticated student by providing spectator's e-mail.
    /// Validates that the current user exists in DB and that the spectator is not the same person.
    /// </summary>
    /// <param name="request">Body containing the spectator's e-mail.</param>
    /// <returns>
    /// 201 when created, 400 for invalid input/self, 401 for bad token, 403 when not a student,
    /// 404 when spectator/current user not found, or relation cannot be created.
    /// </returns>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddMySpectatorByEmailAsync([FromBody] AddSpectatorByEmailDTO request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.SpectatorEmail))
            return BadRequest("A valid spectator email must be provided.");

        try { _ = new MailAddress(request.SpectatorEmail); }
        catch { return BadRequest("Invalid email format."); }

        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var spectatedId))
            return Unauthorized("Invalid or missing user identifier in token.");

        if (!await _usersService.ExistsAsync(spectatedId))
            return NotFound("Current user not found.");
      
        var isStudent = User.FindAll(ClaimTypes.Role)
            .Any(r => r.Value.Equals("student", StringComparison.OrdinalIgnoreCase));
        if (!isStudent)
            return Forbid("Only users with the 'student' role can have spectators.");
        
        var spectatorId = await _usersService.GetIdByEmailAsync(request.SpectatorEmail);
        if (spectatorId is null)
            return NotFound("Spectator user not found.");
        
        if (spectatorId.Value == spectatedId)
            return BadRequest("You cannot add yourself as a spectator.");
        
        var created = await _spectatorsService.AddSpectatorAsync(spectatorId.Value, spectatedId);
        if (!created)
            return NotFound("Unable to create spectatorship. It may already exist or domain rules are not satisfied.");

        return Created();
    }

}