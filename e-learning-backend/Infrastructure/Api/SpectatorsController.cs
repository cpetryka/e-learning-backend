using System.Net.Mail;
using System.Security.Claims;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Security.Impl;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using E_Learning.Domain.Common.Interfaces;
using E_Learning.Infrastructure.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpectatorsController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly ISpectatorsService _spectatorsService;
    private readonly ISpectatorInviteService _inviteService;
    private readonly IEmailTemplateService _emailTemplates;
    private readonly IEmailSender _emailSender;
    private readonly IConfiguration _config;

    public SpectatorsController(
        ISpectatorsService spectatorsService,
        IUsersService usersService,
        IEmailTemplateService emailTemplates,
        IEmailSender emailSender,
        ISpectatorInviteService inviteService,
        IConfiguration configuration
    )
    {
        _spectatorsService = spectatorsService;
        _usersService = usersService;
        _emailTemplates = emailTemplates;
        _emailSender = emailSender;
        _inviteService = inviteService;
        _config = configuration;
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
    /// Creates a spectatorship invitation for the currently authenticated student by specifying the spectator's email address.  
    /// Persists a pending <see cref="SpectatorInvite"/>, generates a secure token, and sends a confirmation email to the invited spectator.
    /// </summary>
    /// <remarks>
    /// This endpoint can be accessed only by authenticated users with the <c>student</c> role.  
    /// It validates the email format, ensures the spectator exists and is not the same as the current user,  
    /// creates an invitation, and sends an email with an acceptance link.
    /// </remarks>
    /// <param name="request">The request payload containing the spectator's email address.</param>
    /// <returns>
    /// <list type="bullet">
    /// <item><b>201 Created</b>   Invitation successfully created and email sent.</item>
    /// <item><b>400 Bad Request</b>   Invalid email address or missing data.</item>
    /// <item><b>401 Unauthorized</b>   Missing or invalid authentication token.</item>
    /// <item><b>403 Forbidden</b>   Current user is not a student.</item>
    /// <item><b>404 Not Found</b>   Current user or spectator not found.</item>
    /// <item><b>409 Conflict</b>   A pending invite for this pair already exists.</item>
    /// <item><b>500 Internal Server Error</b>   Unexpected error while creating or sending the invite.</item>
    /// </list>
    /// </returns>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddMySpectatorByEmailAsync([FromBody] AddSpectatorByEmailDTO request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.SpectatorEmail))
            return BadRequest("A valid spectator email must be provided.");

        try
        {
            _ = new MailAddress(request.SpectatorEmail);
        }
        catch
        {
            return BadRequest("Invalid email format.");
        }

        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var spectatedId))
            return Unauthorized("Invalid or missing user identifier in token.");

        if (!await _usersService.ExistsAsync(spectatedId))
            return NotFound("Current user not found.");

        var isStudent = User.FindAll(ClaimTypes.Role)
            .Any(r => r.Value.Equals("student", StringComparison.OrdinalIgnoreCase));
        if (!isStudent)
            return Forbid();

        // resolve spectator by e-mail
        var spectatorId = await _usersService.GetIdByEmailAsync(request.SpectatorEmail);
        if (spectatorId is null)
            return NotFound("Spectator user not found.");

        if (spectatorId.Value == spectatedId)
            return BadRequest("You cannot add yourself as a spectator.");

        try
        {
            
            var token = SecurityService.CreateSpectatorInviteSecureToken(32);
            var expiresHours = _config.GetValue<int?>("Invitations:ExpiresInHours") ?? 48;
            var expiresAtUtc = DateTime.UtcNow.AddHours(expiresHours);

            var inviteId = await _inviteService.CreateAsync(
                spectatedId: spectatedId,
                spectatorId: spectatorId.Value,
                token: token,
                expiresAtUtc: expiresAtUtc
            );
            
            var appName = _config["App:Name"] ?? "E-Learning";
            var confirmBase = _config["Invitations:ConfirmBaseUrl"] ?? "https://example.com/accept";
            var confirmUrl = $"{confirmBase}?token={Uri.EscapeDataString(token)}";
            var studentName = User.FindFirstValue(ClaimTypes.Name) ?? "Student";

            var model = new Dictionary<string, string>
            {
                ["StudentName"] = studentName,
                ["AppName"] = appName,
                ["ConfirmUrl"] = confirmUrl,
                ["ExpiresAt"] = expiresAtUtc.ToString("yyyy-MM-dd HH:mm 'UTC'")
            };

            var htmlBody = _emailTemplates.RenderHtml("spectator-invite", model);

            await _emailSender.SendEmailAsync(
                to: "elearningpjatk@gmail.com", // here we should use: request.SpectatorEmail to send emails properly
                subject: "Spectator Invitation",
                body: htmlBody,
                isHtml: true
            );

            return Created();
        }
        catch (InvalidOperationException)
        {
            return Conflict("Invite already exists.");
        }
        catch (Exception)
        {
            return Problem("Something went wrong while creating the invite.");
        }
    }


    /// <summary>
    /// Accepts a pending spectator invitation using a provided invitation token.
    /// </summary>
    /// <remarks>
    /// This endpoint can be accessed only by authenticated users.  
    /// It validates the provided token, checks whether the invitation exists and is not expired or already accepted,  
    /// ensures the current user is the invited spectator, and then marks the invitation as accepted.
    /// </remarks>
    /// <param name="request">The request containing the invitation token.</param>
    /// <returns>
    /// <list type="bullet">
    /// <item><b>204 No Content</b>   Invitation successfully accepted.</item>
    /// <item><b>400 Bad Request</b>   Missing or invalid token.</item>
    /// <item><b>401 Unauthorized</b>   Invalid or missing authentication token.</item>
    /// <item><b>403 Forbidden</b>   Current user is not the invited spectator.</item>
    /// <item><b>404 Not Found</b>   Invitation not found.</item>
    /// <item><b>409 Conflict</b>   Invitation already accepted or expired.</item>
    /// <item><b>500 Internal Server Error</b>   Failed to finalize the invitation acceptance.</item>
    /// </list>
    /// </returns>
    [Authorize]
    [HttpPost("invites/accept")]
    public async Task<IActionResult> AcceptInviteAsync([FromBody] AcceptSpectatorInviteDTO request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Token))
            return BadRequest("Token is required.");

        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdStr, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        
        var invite = await _inviteService.GetByTokenAsync(request.Token);
        if (invite is null)
            return NotFound(); 

        if (invite.AcceptedAtUtc != null)
            return Conflict("Invitation already accepted.");

        if (invite.ExpiresAtUtc <= DateTime.UtcNow)
            return Conflict("Invitation time expired."); 

        
        var isSpectator =
            await _usersService.ExistsAsync(currentUserId) &&
            await _inviteService.IsCurrentUserTheSpectatorAsync(invite, currentUserId);
        if (!isSpectator)
            return Forbid();

        
        var ok = await _inviteService.AcceptAsync(invite, currentUserId);
        if (!ok)
            return Problem("Could not accept invitation.", statusCode: 500);

        return NoContent();
    }
    
    [HttpGet("{spectatorId:guid}/spectated")]
    public async Task<IActionResult> GetSpectatedStudents(Guid spectatorId)
    {
        var spectatedStudents = await _spectatorsService.GetSpectatedStudentsAsync(spectatorId);

        return Ok(spectatedStudents);
    }
}