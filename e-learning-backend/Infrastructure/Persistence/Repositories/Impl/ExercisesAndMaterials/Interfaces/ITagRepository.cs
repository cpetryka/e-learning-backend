using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Api.DTO;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tag>> GetAllAsync();
    Task AddAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<GetFileDTO.TagDTO>> GetByUserId(Guid userId, CancellationToken ct = default);
    Task<IEnumerable<GetTagDTO>> GetTagsByUserIdAsync(Guid userId);
    Task<Guid> AddNewTagAsync(AddTagDTO addTagDto);
    Task<bool> ExistAsync(string name, Guid userId);
}