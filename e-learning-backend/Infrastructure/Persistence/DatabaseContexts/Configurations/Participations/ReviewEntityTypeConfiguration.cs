using e_learning_backend.Domain.Participations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.StarsNumber)
            .IsRequired();

        builder.Property(r => r.Content)
            .IsRequired()
            .HasMaxLength(1000);
        
        // Example data
        var reviewId = Guid.Parse("55555555-5555-5555-5555-555555555555");
        var userId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");

        builder.HasData(new
        {
            Id = reviewId,
            StarsNumber = 5,
            Content = "Świetny kurs!",
            ParticipationUserId = userId,
            ParticipationCourseId = courseId
        });
    }
}