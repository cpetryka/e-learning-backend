using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
    private readonly IQuizzesService _quizzesService;
    
    public QuizzesController(IQuizzesService quizzesService)
    {
        _quizzesService = quizzesService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizBriefDTO>>> GetQuizzes(
        [FromQuery] Guid? studentId,
        [FromQuery] Guid? courseId,
        [FromQuery] string? searchQuery)
    {
        var quizzes = await _quizzesService.GetQuizzesAsync(studentId, courseId, searchQuery);

        if (quizzes == null || !quizzes.Any())
            return NoContent();

        return Ok(quizzes);
    }
    
    [HttpGet("{quizId:guid}")]
    public async Task<ActionResult<IEnumerable<QuizBriefDTO>>> GetQuizzes(Guid quizId)
    {
        var quiz = await _quizzesService.GetQuizDetailsAsync(quizId);

        if (quiz == null)
            return NoContent();

        return Ok(quiz);
    }
    
    [HttpGet("{quizId:guid}/questions")]
    public async Task<ActionResult<IEnumerable<QuizQuestionDTO>>> GetQuizQuestions(Guid quizId)
    {
        var questions = await _quizzesService.GetQuizQuestionsAsync(quizId);
        
        if (questions == null || !questions.Any())
            return NoContent();
        
        return Ok(questions);
    }
}