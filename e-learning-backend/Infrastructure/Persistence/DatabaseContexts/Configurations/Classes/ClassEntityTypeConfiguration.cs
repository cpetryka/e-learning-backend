using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ClassEntityTypeConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Status)
            .WithMany()
            .HasForeignKey("ClassStatusId");

        builder.HasOne(c => c.Participation)
            .WithMany(p => p.Classes)
            .HasForeignKey(c => new { c.UserId, c.CourseId });

        builder.HasMany(c => c.Exercises)
            .WithOne(e => e.Class)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Files)
            .WithMany(f => f.Classes)
            .UsingEntity<Dictionary<string, object>>(
                "ClassFileResources", // nazwa tabeli pośredniczącej
                j => j
                    .HasOne<FileResource>()
                    .WithMany()
                    .HasForeignKey("FileResourceId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Class>()
                    .WithMany()
                    .HasForeignKey("ClassId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("ClassId", "FileResourceId");

                    j.HasData(
                        new {
                            ClassId = Guid.Parse("43333333-3333-3333-3333-333333333333"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555555555555")
                        },
                        new {
                            ClassId = Guid.Parse("53333333-3333-3333-3333-333333333333"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555555555555")
                        },
                        new {
                            ClassId = Guid.Parse("73333333-3333-3333-3333-333333333333"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555555555555")
                        },
                        new {
                            ClassId = Guid.Parse("93333333-3333-3333-3333-333333333333"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555555555555")
                        }
                    );
                });

        builder.HasMany(c => c.Links)
            .WithOne(l => l.Class)
            .HasForeignKey(l => l.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        var now = new DateTime(2025, 10, 2, 12, 0, 0, DateTimeKind.Utc);
        var classId = Guid.Parse("43333333-3333-3333-3333-333333333333");
        var statusScheduledId = Guid.Parse("41111111-1111-1111-1111-111111111111");
        var student1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");

        builder.HasData(
            new
            {
                Id = classId,
                StartTime = new DateTime(2025, 5, 8, 19, 24, 25, 619, DateTimeKind.Utc),
                Comment = "Introductory session",
                LinkToMeeting = "https://example.com/meeting",
                ClassStatusId = statusScheduledId,
                UserId = student1Id,
                CourseId = courseId
            },
            new
            {
                Id = Guid.Parse("53333333-3333-3333-3333-333333333333"),
                StartTime = now.AddDays(-2),
                Comment = "Advanced session 1",
                LinkToMeeting = "https://example.com/meeting1",
                ClassStatusId = statusScheduledId,
                UserId = student1Id,
                CourseId = courseId
            },
            new
            {
                Id = Guid.Parse("63333333-3333-3333-3333-333333333333"),
                StartTime = now.AddDays(-5),
                Comment = "Advanced session 2",
                LinkToMeeting = "https://example.com/meeting2",
                ClassStatusId = statusScheduledId,
                UserId = student1Id,
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
            },
            new
            {
                Id = Guid.Parse("73333333-3333-3333-3333-333333333333"),
                StartTime = now.AddDays(-10),
                Comment = "Advanced session 3",
                LinkToMeeting = "https://example.com/meeting3",
                ClassStatusId = statusScheduledId,
                UserId = student1Id,
                CourseId = courseId
            },
            new
            {
                Id = Guid.Parse("83333333-3333-3333-3333-333333333333"),
                StartTime = now.AddDays(-15),
                Comment = "Advanced session 4",
                LinkToMeeting = "https://example.com/meeting4",
                ClassStatusId = statusScheduledId,
                UserId = student1Id,
                CourseId = courseId
            },
            new
            {
                Id = Guid.Parse("93333333-3333-3333-3333-333333333333"),
                StartTime = now.AddDays(-25),
                Comment = "Advanced session 5",
                LinkToMeeting = "https://example.com/meeting5",
                ClassStatusId = statusScheduledId,
                UserId = student1Id,
                CourseId = courseId
            });
    }
}