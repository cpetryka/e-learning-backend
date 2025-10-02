using e_learning_backend.Domain.Classes;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace e_learning_backend.Infrastructure.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipationsController : ControllerBase
{
    private readonly IParticipationRepository _participationRepository;
    
    public ParticipationsController(IParticipationRepository participationRepository)
    {
        _participationRepository = participationRepository;
    }
}