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

        builder.HasData(
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"),
                ReviewId = Guid.Parse("1111111c-0001-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"),
                ReviewId = Guid.Parse("2222222c-0002-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"),
                ReviewId = Guid.Parse("1111111c-0003-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"),
                ReviewId = Guid.Parse("2222222c-0004-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"),
                ReviewId = Guid.Parse("1111111c-0005-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"),
                ReviewId = Guid.Parse("2222222c-0006-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"),
                ReviewId = Guid.Parse("1111111c-0007-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"),
                ReviewId = Guid.Parse("2222222c-0008-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d"),
                ReviewId = Guid.Parse("1111111c-0009-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d"),
                ReviewId = Guid.Parse("2222222c-0010-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"),
                ReviewId = Guid.Parse("1111111c-0011-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"),
                ReviewId = Guid.Parse("2222222c-0012-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2"),
                ReviewId = Guid.Parse("1111111c-0013-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2"),
                ReviewId = Guid.Parse("2222222c-0014-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3"),
                ReviewId = Guid.Parse("1111111c-0015-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3"),
                ReviewId = Guid.Parse("2222222c-0016-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71"),
                ReviewId = Guid.Parse("1111111c-0017-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71"),
                ReviewId = Guid.Parse("2222222c-0018-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"),
                ReviewId = Guid.Parse("1111111c-0019-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"),
                ReviewId = Guid.Parse("2222222c-0020-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"),
                ReviewId = Guid.Parse("1111111c-0021-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"),
                ReviewId = Guid.Parse("2222222c-0022-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15"),
                ReviewId = Guid.Parse("1111111c-0023-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15"),
                ReviewId = Guid.Parse("2222222c-0024-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f"),
                ReviewId = Guid.Parse("1111111c-0025-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f"),
                ReviewId = Guid.Parse("2222222c-0026-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"),
                ReviewId = Guid.Parse("1111111c-0027-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"),
                ReviewId = Guid.Parse("2222222c-0028-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb"),
                ReviewId = Guid.Parse("1111111c-0029-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb"),
                ReviewId = Guid.Parse("2222222c-0030-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0"),
                ReviewId = Guid.Parse("1111111c-0031-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0"),
                ReviewId = Guid.Parse("2222222c-0032-1111-1111-111111111111"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0"), Notifications = false
            },
            new
            {
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb"), Notifications = true
            }
        );
    }
}