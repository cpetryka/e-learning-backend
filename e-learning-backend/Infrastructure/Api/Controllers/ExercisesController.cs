using System.Security.Claims;
using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseService _exerciseService;
    
    public ExercisesController(
        IExerciseRepository exerciseRepository,
        IExerciseService exerciseService)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseService = exerciseService;
    }
    
    [HttpGet("unsolved-by-user/{userId}")]
    public async Task<IActionResult> GetAllUnsolvedExercisesByUserId(Guid userId)
    {
        var exercises = await _exerciseRepository.GetAllUnsolvedExercisesByUserId(userId);
        return Ok(exercises);
    }
    
    [HttpGet("by-teacher/{teacherId:guid}")]
    public async Task<IActionResult> GetAllExercisesByTeacherId(Guid teacherId)
    {
        var exercises = await _exerciseRepository.GetAllExercisesByTeacherId(teacherId);
        return Ok(exercises);
    }
    
    

    [HttpPost("grade")]
    public async Task<IActionResult> GradeAssignment([FromBody] GradeExerciseRequestDTO request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var currentUserId))
            return Unauthorized("Invalid or missing user identifier.");

        var success = await _exerciseService.GradeExerciseAsync(
            request.AssignmentId,
            request.Grade,
            request.Comments,
            currentUserId);

        if (!success)
            return Forbid(); 

        return NoContent();
    }
    
}