using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;

namespace e_learning_backend.Application.Services.Interfaces;

public interface ITagsService
{
    Task<IEnumerable<GetTagDTO>> GetTagsByUserIdAsync(Guid userId);
    Task<Guid> AddNewTagAsync(Guid userId, AddTagDTO addTagDto);
}