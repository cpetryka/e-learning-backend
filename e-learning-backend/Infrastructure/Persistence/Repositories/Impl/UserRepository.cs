using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class UserRepository : IUsersRepository
{
    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context) => _context = context;

    public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == id);
}