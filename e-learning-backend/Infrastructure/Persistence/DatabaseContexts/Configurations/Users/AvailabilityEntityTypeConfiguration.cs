using e_learning_backend.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class AvailabilityEntityTypeConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Date).IsRequired();

        builder.HasOne(a => a.Teacher)
            .WithMany(u => u.Availability)
            .HasForeignKey(a => a.TeacherId);

        builder.HasMany(a => a.TimeSlots)
            .WithOne(t => t.Availability)
            .HasForeignKey(t => t.AvailabilityId);

        builder.HasData(
    new { Id = Guid.Parse("aaaa0001-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 19, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0002-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 24, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0003-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 20, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0004-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 8, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0005-0000-0000-0000-000000000000"), Date = new DateTime(2025, 8, 27, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0006-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 27, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0007-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 22, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0008-0000-0000-0000-000000000000"), Date = new DateTime(2025, 8, 29, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0009-0000-0000-0000-000000000000"), Date = new DateTime(2025, 8, 28, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0010-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 14, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0011-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 10, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0012-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 25, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0013-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0014-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 18, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0015-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 6, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0016-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 25, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0017-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 2, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0018-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0019-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 10, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0020-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0021-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 7, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0022-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 9, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0023-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0024-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 18, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0025-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0026-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0027-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 14, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0028-0000-0000-0000-000000000000"), Date = new DateTime(2025, 8, 28, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0029-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 20, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0030-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 8, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0031-0000-0000-0000-000000000000"), Date = new DateTime(2025, 8, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0032-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 18, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0033-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0034-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 27, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0035-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 25, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0036-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 14, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0037-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 28, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0038-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 12, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0039-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 9, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0040-0000-0000-0000-000000000000"), Date = new DateTime(2025, 8, 31, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0041-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 16, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0042-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 17, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0043-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 6, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0044-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 29, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0045-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 17, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0046-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 1, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0047-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 24, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0048-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 6, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0049-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 23, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("aaaa0050-0000-0000-0000-000000000000"), Date = new DateTime(2025, 9, 16, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") }
);
    }
}