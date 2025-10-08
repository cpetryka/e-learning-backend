using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Application.Services;

public class SpectatorsService : ISpectatorsService
{
    private readonly ISpectatorsRepository _spectatorsRepository;

    public SpectatorsService(ISpectatorsRepository spectatorsRepository)
    {
        _spectatorsRepository = spectatorsRepository;
    }

  
    public Task<IEnumerable<SpectatorDTO>> GetSpectatedByAsync(Guid userId)
        => _spectatorsRepository.GetSpectatedByAsync(userId);
    
    public Task<bool> RemoveSpectatorAsync(Guid spectatorId, Guid spectatedId)
        => _spectatorsRepository.RemoveSpectatorAsync(spectatorId, spectatedId);

    public Task<bool> AddSpectatorAsync(Guid spectatorId, Guid spectatedId)
        => _spectatorsRepository.AddSpectatorAsync(spectatorId, spectatedId);
}