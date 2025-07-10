using e_learning_backend.Domain.Participations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ParticipationEntityTypeConfiguration : IEntityTypeConfiguration<Participation>
{
    public void Configure(EntityTypeBuilder<Participation> builder)
    {
        builder.HasKey(p => new { p.UserId, p.CourseId });

        builder.HasOne(p => p.User)
            .WithMany(u => u.Participations)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.Course)
            .WithMany(c => c.Participations)
            .HasForeignKey(p => p.CourseId);

        builder.Property(p => p.Notifications);

        // Example data (commented out by default)
        var student1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var student2Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");

        builder.HasData(
            new { UserId = student1Id, CourseId = courseId, Notifications = false },
            new { UserId = student2Id, CourseId = courseId, Notifications = true }
        );
    }
}