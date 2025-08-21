using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Infrastructure.Security.Impl;

public class UsersService : IUsersService
{
    private readonly ApplicationContext _context;
    
    public UsersService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<AboutMeDTO?> GetAboutMeAsync(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId);

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