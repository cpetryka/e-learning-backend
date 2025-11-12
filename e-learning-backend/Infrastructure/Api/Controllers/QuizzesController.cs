using System.Security.Claims;
using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Extensions;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
    private readonly IQuizzesService _quizzesService;
    private readonly IUsersService _usersService;
    
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
    
    [HttpGet("user/categories")]
    public async Task<ActionResult<IEnumerable<QuestionCategoryDTO>>> GetUserQuestionCategories()
    {
        var userId = User.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }
        
        var categories = await _quizzesService.GetUserQuestionCategoriesAsync(userId.Value);
        
        if (categories == null || !categories.Any())
            return NoContent();
        
        return Ok(categories);
    }
    
    [HttpGet("user/questions")]
    public async Task<ActionResult<IEnumerable<QuizQuestionDTO>>> GetUserQuestions(
        [FromQuery(Name = "categories")] List<Guid>? categoryIds)
    {
        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized();

        var questions = await _quizzesService.GetUserQuestionsAsync(userId.Value, categoryIds);

        if (questions == null || !questions.Any())
            return NoContent();

        return Ok(questions);
    }

    [HttpGet("question/{questionId:guid}/full")]
    public async Task<ActionResult<QuizQuestionDTO>> GetFullQuestion(Guid questionId)
    {
        var question = await _quizzesService.GetFullQuestionAsync(questionId);

        if (question == null)
            return NotFound();

        return Ok(question);
    }
    
    [HttpPost("question/category")]
    public async Task<ActionResult<QuestionCategoryDTO>> CreateQuestionCategory([FromBody] CreateQuestionCategoryDTO categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
            return BadRequest("Category name cannot be empty.");

        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized();

        var category = await _quizzesService.CreateQuestionCategoryAsync(userId.Value, categoryDto.Name);

        if (category == null)
            return StatusCode(500, "Failed to create category.");

        return Ok(category);
    }
}