using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Infrastructure.Security.Impl;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    
    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<AboutMeDTO?> GetAboutMeAsync(Guid userId)
    {
        var user = await _usersRepository.GetByIdAsync(userId);

        if (user == null)
            return null;

        return new AboutMeDTO
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            PhoneNumber = user.Phone,
            Description = user.AboutMe,
        };
    }
}