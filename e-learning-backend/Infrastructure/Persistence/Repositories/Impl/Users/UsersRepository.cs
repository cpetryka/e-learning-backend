using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationContext _context;

    public UsersRepository(ApplicationContext context) => _context = context;

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
    
    public Task<bool> ExistsAsync(Guid userId)
        => _context.Users.AsNoTracking().AnyAsync(u => u.Id == userId);
    
    public async Task<Guid?> GetIdByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return null;
        var normalized = email.Trim().ToLowerInvariant();

        return await _context.Users.AsNoTracking()
            .Where(u => u.Email.ToLower() == normalized)
            .Select(u => (Guid?)u.Id)
            .SingleOrDefaultAsync();
    }
}