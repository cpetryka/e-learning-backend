using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class UserRepository : IUsersRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context) => _context = context;

    public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(u => u.Id == id);
    
    public async Task<IEnumerable<User>> GetAllAsync()
        => await _context.Users
            .Include(u => u.Roles)
            .ToListAsync();
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}