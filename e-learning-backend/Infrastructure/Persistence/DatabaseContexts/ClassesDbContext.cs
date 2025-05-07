using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Classes.ValueObjects;
using Microsoft.EntityFrameworkCore;

public class ClassesDbContext : DbContext
{
    public DbSet<Class> Classes { get; set; }
    public DbSet<ClassStatus> ClassStatuses { get; set; }

    protected ClassesDbContext() { }

    public ClassesDbContext(DbContextOptions<ClassesDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Class>().HasKey(c => c.Id);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Status)
            .WithMany()
            .HasForeignKey("ClassStatusId");

        modelBuilder.Entity<ClassStatus>().HasKey(s => s.Id);

        var statusScheduledId = Guid.Parse("41111111-1111-1111-1111-111111111111");
        var statusDoneId = Guid.Parse("42222222-2222-2222-2222-222222222222");
        var classId = Guid.Parse("43333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<ClassStatus>().HasData(
            new ClassStatus(statusScheduledId, "Scheduled"),
            new ClassStatus(statusDoneId, "Done")
        );

        modelBuilder.Entity<Class>().HasData(new
        {
            Id = classId,
            StartTime = new DateTime(2025, 5, 8, 19, 24, 25, 619, DateTimeKind.Utc),
            Comment = "Introductory session",
            LinkToMeeting = "https://example.com/meeting",
            ClassStatusId = statusScheduledId
        });
    }
}