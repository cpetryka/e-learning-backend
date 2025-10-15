using e_learning_backend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository;
    
    public ExercisesController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    
    [HttpGet("unsolved-by-user/{userId}")]
    public async Task<IActionResult> GetAllUnsolvedExercisesByUserId(Guid userId)
    {
        var exercises = await _exerciseRepository.GetAllUnsolvedExercisesByUserId(userId);
        return Ok(exercises);
    }
}