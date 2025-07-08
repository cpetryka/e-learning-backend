using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected UsersDbContext() { }

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(u =>
        {
            // Seed the User table with sample data
            var teacherId             = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var student1Id            = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var student2Id            = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var spectatorStudentId    = Guid.Parse("44444444-4444-4444-4444-444444444444");

            var salt = "$2a$12$abcdefghijklmnopqrstuv";
            
            // Primary key
            u.HasKey(x => x.Id);

            // Scalar properties
            u.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            u.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            u.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);
            u.HasIndex(x => x.Email).IsUnique();

            u.Property(x => x.HashedPassword)
                .IsRequired();

            u.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(20);

            u.Property(x => x.AboutMe)
                .HasMaxLength(1000);

            u.Property(x => x.RefreshToken)
                .HasMaxLength(500);

            u.Property(x => x.RefreshTokenExpiryTime);
            
            u.HasMany(u => u.BlockedUsers) // Użytkownik ma wielu zablokowanych użytkowników
                .WithMany() // Brak jawnej właściwości nawigacyjnej po drugiej stronie
                .UsingEntity( // Konfiguracja tabeli pośredniczącej
                    "UserBlockedUsers",
                    l => l.HasOne(typeof(User)) // Strona "lewa" (użytkownik, który blokuje)
                        .WithMany()
                        .HasForeignKey("BlockingUserId") // Klucz obcy dla użytkownika blokującego
                        .HasPrincipalKey(nameof(User.Id)), // Klucz główny w encji User
                    r => r.HasOne(typeof(User)) // Strona "prawa" (użytkownik, który jest blokowany)
                        .WithMany()
                        .HasForeignKey("BlockedUserId") // Klucz obcy dla użytkownika blokowanego
                        .HasPrincipalKey(nameof(User.Id)),
                    j => j.HasData( // Dodawanie danych do tabeli pośredniczącej UserBlockedUsers
                        new { BlockingUserId = teacherId, BlockedUserId = student1Id }
                    )
                );

            u.HasData(
                new
                {
                    Id                     = teacherId,
                    Name                   = "Alice",
                    Surname                = "Johnson",
                    Email                  = "alice.johnson@example.com",
                    HashedPassword         = BCrypt.Net.BCrypt.HashPassword("teacher", salt),
                    Phone                  = "+1-202-555-0101",
                    AboutMe                = "Passionate about teaching mathematics.",
                    RefreshToken           = (string?)null,
                    RefreshTokenExpiryTime = (DateTime?)null
                },
                new
                {
                    Id                     = student1Id,
                    Name                   = "John",
                    Surname                = "Doe",
                    Email                  = "john.doe@example.com",
                    HashedPassword         = BCrypt.Net.BCrypt.HashPassword("student1", salt),
                    Phone                  = "+1-202-555-0102",
                    AboutMe                = (string?)null,
                    RefreshToken           = (string?)null,
                    RefreshTokenExpiryTime = (DateTime?)null
                },
                new
                {
                    Id                     = student2Id,
                    Name                   = "Jane",
                    Surname                = "Doe",
                    Email                  = "jane.doe@example.com",
                    HashedPassword         = BCrypt.Net.BCrypt.HashPassword("student2", salt),
                    Phone                  = "+1-202-555-0103",
                    AboutMe                = (string?)null,
                    RefreshToken           = (string?)null,
                    RefreshTokenExpiryTime = (DateTime?)null
                },
                new
                {
                    Id                     = spectatorStudentId,
                    Name                   = "Michael",
                    Surname                = "Brown",
                    Email                  = "michael.brown@example.com",
                    HashedPassword         = BCrypt.Net.BCrypt.HashPassword("spectatorStudent", salt),
                    Phone                  = "+1-202-555-0104",
                    AboutMe                = "Enjoys following courses as a spectator.",
                    RefreshToken           = (string?)null,
                    RefreshTokenExpiryTime = (DateTime?)null
                }
            );

            // Map the Roles value-object collection as an owned entity
            u.OwnsMany(x => x.Roles, r =>
            {
                r.WithOwner().HasForeignKey("UserId");
                r.Property<string>("RoleName")
                    .HasColumnName("RoleName")
                    .IsRequired();
                r.HasKey("UserId", "RoleName");
                r.ToTable("UserRoles");

                // Seed the UserRoles table
                r.HasData(
                    // one teacher
                    new { UserId = teacherId,          RoleName = Role.Teacher.RoleName },
                    // two regular students
                    new { UserId = student1Id,         RoleName = Role.Student.RoleName },
                    new { UserId = student2Id,         RoleName = Role.Student.RoleName },
                    // one student-spectator
                    new { UserId = spectatorStudentId, RoleName = Role.Student.RoleName },
                    new { UserId = spectatorStudentId, RoleName = Role.Spectator.RoleName }
                );
            });
        });
    }
}