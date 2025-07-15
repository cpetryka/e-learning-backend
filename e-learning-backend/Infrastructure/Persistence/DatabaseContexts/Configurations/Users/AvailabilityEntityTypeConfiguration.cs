using e_learning_backend.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class AvailabilityEntityTypeConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Date)
            .IsRequired();

        builder.HasOne(a => a.Teacher)
            .WithMany(u => u.Availability)
            .HasForeignKey(a => a.TeacherId);

        builder.HasMany(a => a.TimeSlots)
            .WithOne(t => t.Availability)
            .HasForeignKey(t => t.AvailabilityId);

        // Example seed
        var availabilityId = Guid.Parse("f1111111-1111-1111-1111-111111111111");
        var teacherId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        builder.HasData(new
        {
            Id = availabilityId,
            Date = new DateTime(2025, 7, 10, 0, 0, 0, DateTimeKind.Utc),
            TeacherId = teacherId
        });
    }
}