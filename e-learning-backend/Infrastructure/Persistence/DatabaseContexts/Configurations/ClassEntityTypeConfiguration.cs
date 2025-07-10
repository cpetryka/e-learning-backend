using e_learning_backend.Domain.Classes;
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

        var classId = Guid.Parse("43333333-3333-3333-3333-333333333333");
        var statusScheduledId = Guid.Parse("41111111-1111-1111-1111-111111111111");

        builder.HasData(new
        {
            Id = classId,
            StartTime = new DateTime(2025, 5, 8, 19, 24, 25, 619, DateTimeKind.Utc),
            Comment = "Introductory session",
            LinkToMeeting = "https://example.com/meeting",
            ClassStatusId = statusScheduledId
        });
    }
}