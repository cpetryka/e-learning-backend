using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var teacherId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var teacher2Id = Guid.Parse("555e5555-5555-5555-5555-555555555555");
        var teacher3Id = Guid.Parse("666e6666-6666-6666-6666-666666666666");
        
        var student1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var student2Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var spectatorStudentId = Guid.Parse("44444444-4444-4444-4444-444444444444");


        var salt = "$2a$12$abcdefghijklmnopqrstuv";

        // Primary key
        builder.HasKey(x => x.Id);

        // Scalar properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Surname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.HashedPassword)
            .IsRequired();

        builder.Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.AboutMe)
            .HasMaxLength(1000);

        builder.Property(x => x.RefreshToken)
            .HasMaxLength(500);

        builder.Property(x => x.RefreshTokenExpiryTime);
        
        builder.OwnsOne(u => u.ProfilePicture, pp =>
        {
            pp.Property(p => p.FileName)
                .HasMaxLength(255)
                .HasColumnName("ProfilePictureFileName");

            pp.Property(p => p.FilePath)
                .HasMaxLength(500)
                .HasColumnName("ProfilePictureFilePath");

            pp.Property(p => p.UploadedAt)
                .HasColumnName("ProfilePictureUploadedAt");
        });


        // BlockedUsers many-to-many relationship
        builder.HasMany(u => u.BlockedUsers)
            .WithMany(u => u.BlockedByUsers)
            .UsingEntity<Dictionary<string, object>>(
                "BlockedUsers",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("BlockedUserId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("BlockingUserId")
                    .OnDelete(DeleteBehavior.Restrict),
                j =>
                {
                    j.HasKey("BlockingUserId", "BlockedUserId");

                    j.HasData(new
                    {
                        BlockingUserId = teacherId,
                        BlockedUserId = student1Id
                    });
                }
            );

        builder.HasMany(u => u.Availability)
            .WithOne(a => a.Teacher)
            .HasForeignKey(a => a.TeacherId);

        builder.HasMany(u => u.Spectates)
            .WithMany(u => u.SpectatedBy)
            .UsingEntity<Dictionary<string, object>>(
                "UserSpectators",
                l => l.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("SpectatedUserId")
                    .OnDelete(DeleteBehavior.NoAction),
                r => r.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("SpectatorUserId")
                    .OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.HasKey("SpectatedUserId", "SpectatorUserId");
                    j.ToTable("UserSpectators");

                    j.HasData(new
                    {
                        SpectatedUserId = teacherId, // student
                        SpectatorUserId = spectatorStudentId // spectator
                    });
                });
        
        

        // Seed users
        builder.HasData(
            new
            {
                Id = teacherId,
                Name = "Alice",
                Surname = "Johnson",
                Email = "alice.johnson@example.com",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("teacher", salt),
                Phone = "+1-202-555-0101",
                AboutMe = "Passionate about teaching mathematics.",
                RefreshToken = (string?)null,
                RefreshTokenExpiryTime = (DateTime?)null
            },
            new
            {
                Id = teacher2Id,
                Name = "Robert",
                Surname = "Smith",
                Email = "robert.smith@example.com",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("teacher2", salt),
                Phone = "+1-202-555-0105",
                AboutMe = "Physics enthusiast who loves experiments.",
                RefreshToken = (string?)null,
                RefreshTokenExpiryTime = (DateTime?)null
            },
            new
            {
                Id = teacher3Id,
                Name = "Emily",
                Surname = "Davis",
                Email = "emily.davis@example.com",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("teacher3", salt),
                Phone = "+1-202-555-0106",
                AboutMe = "English teacher passionate about literature.",
                RefreshToken = (string?)null,
                RefreshTokenExpiryTime = (DateTime?)null
            },
            new
            {
                Id = student1Id,
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@example.com",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("student1", salt),
                Phone = "+1-202-555-0102",
                AboutMe = (string?)null,
                RefreshToken = (string?)null,
                RefreshTokenExpiryTime = (DateTime?)null
            },
            new
            {
                Id = student2Id,
                Name = "Jane",
                Surname = "Doe",
                Email = "jane.doe@example.com",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("student2", salt),
                Phone = "+1-202-555-0103",
                AboutMe = (string?)null,
                RefreshToken = (string?)null,
                RefreshTokenExpiryTime = (DateTime?)null
            },
            new
            {
                Id = spectatorStudentId,
                Name = "Michael",
                Surname = "Brown",
                Email = "michael.brown@example.com",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("spectatorStudent", salt),
                Phone = "+1-202-555-0104",
                AboutMe = "Enjoys following courses as a spectator.",
                RefreshToken = (string?)null,
                RefreshTokenExpiryTime = (DateTime?)null
            }
        );

        // Map the Roles value-object collection as an owned entity
        builder.OwnsMany(x => x.Roles, r =>
        {
            r.WithOwner().HasForeignKey("UserId");
            r.Property<string>("RoleName")
                .HasColumnName("RoleName")
                .IsRequired();
            r.HasKey("UserId", "RoleName");
            r.ToTable("UserRoles");

            r.HasData(
                new { UserId = teacherId, RoleName = Role.Teacher.RoleName },
                new { UserId = teacher2Id, RoleName = Role.Teacher.RoleName },
                new { UserId = teacher3Id, RoleName = Role.Teacher.RoleName },
                new { UserId = student1Id, RoleName = Role.Student.RoleName },
                new { UserId = student2Id, RoleName = Role.Student.RoleName },
                new { UserId = spectatorStudentId, RoleName = Role.Student.RoleName },
                new { UserId = spectatorStudentId, RoleName = Role.Spectator.RoleName }
            );
        });
    }
}