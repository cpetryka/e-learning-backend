using e_learning_backend.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class TimeSlotEntityTypeConfiguration : IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.StartTime).IsRequired();
        builder.Property(t => t.EndTime).IsRequired();

        builder.HasOne(t => t.Availability)
            .WithMany(a => a.TimeSlots)
            .HasForeignKey(t => t.AvailabilityId);

        // Example seed
        builder.HasData(
            new
            {
                Id = Guid.Parse("f2222222-2222-2222-2222-222222222222"),
                StartTime = new DateTime(2025, 07, 15, 9, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2025, 07, 15, 10, 0, 0, DateTimeKind.Utc),
                AvailabilityId = Guid.Parse("f1111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                StartTime = new DateTime(2025, 07, 15, 10, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2025, 07, 15, 11, 0, 0, DateTimeKind.Utc),
                AvailabilityId = Guid.Parse("f1111111-1111-1111-1111-111111111111")
            }
        );
    }
}