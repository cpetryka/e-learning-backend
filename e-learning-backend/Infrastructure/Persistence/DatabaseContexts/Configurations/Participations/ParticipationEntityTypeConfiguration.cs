using e_learning_backend.Domain.Participations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ParticipationEntityTypeConfiguration : IEntityTypeConfiguration<Participation>
{
    public void Configure(EntityTypeBuilder<Participation> builder)
    {
        builder.HasKey(p => new { p.UserId, p.CourseVariantId });

        builder.HasOne(p => p.User)
            .WithMany(u => u.Participations)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.CourseVariant)
            .WithMany(c => c.Participations)
            .HasForeignKey(p => p.CourseVariantId);

        /*builder.HasOne(p => p.Review)
            .WithOne(r => r.Participation)
            .HasForeignKey<Participation>(p => p.ReviewId);*/

        builder.Property(p => p.Notifications);

        builder.HasData(
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("82502dbb-dd0d-436c-8973-439f54f30307"), // Było: 0042b980...
                ReviewId = Guid.Parse("1111111c-0001-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("82502dbb-dd0d-436c-8973-439f54f30307"), // Było: 0042b980...
                ReviewId = Guid.Parse("2222222c-0002-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("97904238-f028-4e42-8676-5067dd3b2f48"), // Było: c29ad7cb...
                ReviewId = Guid.Parse("1111111c-0003-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("97904238-f028-4e42-8676-5067dd3b2f48"), // Było: c29ad7cb...
                ReviewId = Guid.Parse("2222222c-0004-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("fe7615e2-cd45-4307-9e74-a837f2b4d606"), // Było: f31eb3f2...
                ReviewId = Guid.Parse("1111111c-0005-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("fe7615e2-cd45-4307-9e74-a837f2b4d606"), // Było: f31eb3f2...
                ReviewId = Guid.Parse("2222222c-0006-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("ea675454-f59a-4c5e-978b-a674f7d7fbaf"), // Było: e4c2a925...
                ReviewId = Guid.Parse("1111111c-0007-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("ea675454-f59a-4c5e-978b-a674f7d7fbaf"), // Było: e4c2a925...
                ReviewId = Guid.Parse("2222222c-0008-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("72e7ead9-5ed8-4eac-bbef-ff39303c1d6f"), // Było: 99d1436e...
                ReviewId = Guid.Parse("1111111c-0009-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("72e7ead9-5ed8-4eac-bbef-ff39303c1d6f"), // Było: 99d1436e...
                ReviewId = Guid.Parse("2222222c-0010-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("2bb9df2c-c27b-424c-8814-7c38b00045e8"), // Było: f5f9237d...
                ReviewId = Guid.Parse("1111111c-0011-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("2bb9df2c-c27b-424c-8814-7c38b00045e8"), // Było: f5f9237d...
                ReviewId = Guid.Parse("2222222c-0012-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("e1fc1975-94ce-4181-b485-0d6c05a5a1b8"), // Było: 7f3d823c...
                ReviewId = Guid.Parse("1111111c-0013-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("e1fc1975-94ce-4181-b485-0d6c05a5a1b8"), // Było: 7f3d823c...
                ReviewId = Guid.Parse("2222222c-0014-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("9f219956-15d4-459f-89ef-c6b833ae8adb"), // Było: d1b85095...
                ReviewId = Guid.Parse("1111111c-0015-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("9f219956-15d4-459f-89ef-c6b833ae8adb"), // Było: d1b85095...
                ReviewId = Guid.Parse("2222222c-0016-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("c89fe8aa-1778-4a06-bc5f-74b646e229db"), // Było: 6e3a3c34...
                ReviewId = Guid.Parse("1111111c-0017-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("c89fe8aa-1778-4a06-bc5f-74b646e229db"), // Było: 6e3a3c34...
                ReviewId = Guid.Parse("2222222c-0018-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("9b77a2fb-6522-45dd-ae91-e5b84d0a3951"), // Było: fb003b55...
                ReviewId = Guid.Parse("1111111c-0019-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("9b77a2fb-6522-45dd-ae91-e5b84d0a3951"), // Było: fb003b55...
                ReviewId = Guid.Parse("2222222c-0020-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("ce899111-a22d-4cca-bd65-fcfa633754b9"), // Było: 78f0e23b...
                ReviewId = Guid.Parse("1111111c-0021-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("ce899111-a22d-4cca-bd65-fcfa633754b9"), // Było: 78f0e23b...
                ReviewId = Guid.Parse("2222222c-0022-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("52540491-ae28-4d37-b551-9ab7883c2dd2"), // Było: a0e86a5c...
                ReviewId = Guid.Parse("1111111c-0023-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("52540491-ae28-4d37-b551-9ab7883c2dd2"), // Było: a0e86a5c...
                ReviewId = Guid.Parse("2222222c-0024-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("a415a739-5557-4d0e-8980-68bb3ba2aa7e"), // Było: 44d62488...
                ReviewId = Guid.Parse("1111111c-0025-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("a415a739-5557-4d0e-8980-68bb3ba2aa7e"), // Było: 44d62488...
                ReviewId = Guid.Parse("2222222c-0026-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("32637827-fe2d-4a40-9641-8b18a9df1cfb"), // Było: b9427e4d...
                ReviewId = Guid.Parse("1111111c-0027-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("32637827-fe2d-4a40-9641-8b18a9df1cfb"), // Było: b9427e4d...
                ReviewId = Guid.Parse("2222222c-0028-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2"), // Było: b13306f3...
                ReviewId = Guid.Parse("1111111c-0029-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2"), // Było: b13306f3...
                ReviewId = Guid.Parse("2222222c-0030-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseVariantId =
                    Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178"), // Było: b39f4f06...
                ReviewId = Guid.Parse("1111111c-0031-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseVariantId =
                    Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178"), // Było: b39f4f06...
                ReviewId = Guid.Parse("2222222c-0032-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseVariantId =
                    Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178"), // Było: b39f4f06...
                Notifications = false
            },
            new
            {
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseVariantId =
                    Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2"), // Było: b13306f3...
                Notifications = true
            }
        );
    }
}