using e_learning_backend.Application.Services.Interfaces;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;

namespace e_learning_backend.Application.Services;

public class TagsService : ITagsService
{
    private readonly ITagRepository _tagRepository;

    public TagsService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<GetTagDTO>> GetTagsByUserIdAsync(Guid userId)
    {
        return await _tagRepository.GetTagsByUserIdAsync(userId);
    }
    
    public async Task<Guid> AddNewTagAsync(Guid userId, AddTagDTO addTagDto)
    {
        return await _tagRepository.AddNewTagAsync(userId, addTagDto);
    }
}