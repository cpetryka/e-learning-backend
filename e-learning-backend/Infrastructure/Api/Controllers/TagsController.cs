using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Extensions;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagRepository _tagRepository;
    private readonly ITagsService _tagsService;
    
    public TagsController(ITagRepository tagRepository, ITagsService tagsService)
    {
        _tagRepository = tagRepository;
        _tagsService = tagsService;
    }
    
    [HttpGet("by-user/{userId}")]
    public async Task<IActionResult> GetTagsByUserId(Guid userId)
    {
        var tags = await _tagsService.GetTagsByUserIdAsync(userId);
        return Ok(tags);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewTag([FromBody] AddTagDTO addTagDto)
    {
        var userId = User.GetUserId();
        
        if (userId == null)
            return Unauthorized();
        
        if (await _tagRepository.ExistAsync(addTagDto.Name, userId.Value))
        {
            return Conflict("Tag with the same name already exists for this user.");
        } 
        
        var tagId = await _tagsService.AddNewTagAsync(userId.Value, addTagDto);
        return Ok(new { TagId = tagId });
    }
}