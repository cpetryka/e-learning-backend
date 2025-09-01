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

        builder.HasOne(p => p.Review)
            .WithOne(r => r.Participation)
            .HasForeignKey<Participation>(p => p.ReviewId);

        builder.Property(p => p.Notifications);

        // Example data with ReviewId set
        var student1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var student2Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");
        var reviewId = Guid.Parse("55555555-5555-5555-5555-555555555555");

        builder.HasData(
            new { UserId = student1Id, CourseId = courseId, ReviewId = reviewId, Notifications = false },
            new { UserId = student2Id, CourseId = courseId, ReviewId = (Guid?)null, Notifications = true } // brak recenzji
        );
    }

}