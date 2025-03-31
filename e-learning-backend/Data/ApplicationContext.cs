using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext() { }

    public ApplicationContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}