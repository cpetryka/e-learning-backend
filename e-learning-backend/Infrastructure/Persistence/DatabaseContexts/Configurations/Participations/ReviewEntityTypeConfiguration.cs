using e_learning_backend.Domain.Participations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.HasOne(r => r.Participation)
            .WithOne(p => p.Review)
            .HasForeignKey<Review>(r => new { r.ParticipationUserId, r.ParticipationCourseVariantId })
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(r => r.StarsNumber).IsRequired();
        builder.Property(r => r.Content).IsRequired().HasMaxLength(1000);

builder.HasData(
    new { Id = Guid.Parse("1111111c-0001-1111-1111-111111111111"), StarsNumber = 1, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("82502dbb-dd0d-436c-8973-439f54f30307") },
    new { Id = Guid.Parse("2222222c-0002-1111-1111-111111111111"), StarsNumber = 3, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("82502dbb-dd0d-436c-8973-439f54f30307") },
    new { Id = Guid.Parse("1111111c-0003-1111-1111-111111111111"), StarsNumber = 5, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("97904238-f028-4e42-8676-5067dd3b2f48") },
    new { Id = Guid.Parse("2222222c-0004-1111-1111-111111111111"), StarsNumber = 5, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("97904238-f028-4e42-8676-5067dd3b2f48") },
    new { Id = Guid.Parse("1111111c-0005-1111-1111-111111111111"), StarsNumber = 5, Content = "Instructor was very clear and supportive.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("fe7615e2-cd45-4307-9e74-a837f2b4d606") },
    new { Id = Guid.Parse("2222222c-0006-1111-1111-111111111111"), StarsNumber = 5, Content = "Instructor was very clear and supportive.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("fe7615e2-cd45-4307-9e74-a837f2b4d606") },
    new { Id = Guid.Parse("1111111c-0007-1111-1111-111111111111"), StarsNumber = 2, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("ea675454-f59a-4c5e-978b-a674f7d7fbaf") },
    new { Id = Guid.Parse("2222222c-0008-1111-1111-111111111111"), StarsNumber = 3, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("ea675454-f59a-4c5e-978b-a674f7d7fbaf") },
    new { Id = Guid.Parse("1111111c-0009-1111-1111-111111111111"), StarsNumber = 3, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("72e7ead9-5ed8-4eac-bbef-ff39303c1d6f") },
    new { Id = Guid.Parse("2222222c-0010-1111-1111-111111111111"), StarsNumber = 5, Content = "Instructor was very clear and supportive.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("72e7ead9-5ed8-4eac-bbef-ff39303c1d6f") },
    new { Id = Guid.Parse("1111111c-0011-1111-1111-111111111111"), StarsNumber = 1, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("2bb9df2c-c27b-424c-8814-7c38b00045e8") },
    new { Id = Guid.Parse("2222222c-0012-1111-1111-111111111111"), StarsNumber = 4, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("2bb9df2c-c27b-424c-8814-7c38b00045e8") },
    new { Id = Guid.Parse("1111111c-0013-1111-1111-111111111111"), StarsNumber = 4, Content = "The course was okay, but not engaging.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("e1fc1975-94ce-4181-b485-0d6c05a5a1b8") },
    new { Id = Guid.Parse("2222222c-0014-1111-1111-111111111111"), StarsNumber = 4, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("e1fc1975-94ce-4181-b485-0d6c05a5a1b8") },
    new { Id = Guid.Parse("1111111c-0015-1111-1111-111111111111"), StarsNumber = 3, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("9f219956-15d4-459f-89ef-c6b833ae8adb") },
    new { Id = Guid.Parse("2222222c-0016-1111-1111-111111111111"), StarsNumber = 5, Content = "Great course, learned a lot!", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("9f219956-15d4-459f-89ef-c6b833ae8adb") },
    new { Id = Guid.Parse("1111111c-0017-1111-1111-111111111111"), StarsNumber = 3, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("c89fe8aa-1778-4a06-bc5f-74b646e229db") },
    new { Id = Guid.Parse("2222222c-0018-1111-1111-111111111111"), StarsNumber = 2, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("c89fe8aa-1778-4a06-bc5f-74b646e229db") },
    new { Id = Guid.Parse("1111111c-0019-1111-1111-111111111111"), StarsNumber = 1, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("9b77a2fb-6522-45dd-ae91-e5b84d0a3951") },
    new { Id = Guid.Parse("2222222c-0020-1111-1111-111111111111"), StarsNumber = 1, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("9b77a2fb-6522-45dd-ae91-e5b84d0a3951") },
    new { Id = Guid.Parse("1111111c-0021-1111-1111-111111111111"), StarsNumber = 3, Content = "Excellent explanations, highly recommend.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("ce899111-a22d-4cca-bd65-fcfa633754b9") },
    new { Id = Guid.Parse("2222222c-0022-1111-1111-111111111111"), StarsNumber = 2, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("ce899111-a22d-4cca-bd65-fcfa633754b9") },
    new { Id = Guid.Parse("1111111c-0023-1111-1111-111111111111"), StarsNumber = 4, Content = "The course was okay, but not engaging.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("52540491-ae28-4d37-b551-9ab7883c2dd2") },
    new { Id = Guid.Parse("2222222c-0024-1111-1111-111111111111"), StarsNumber = 2, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("52540491-ae28-4d37-b551-9ab7883c2dd2") },
    new { Id = Guid.Parse("1111111c-0025-1111-1111-111111111111"), StarsNumber = 1, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("a415a739-5557-4d0e-8980-68bb3ba2aa7e") },
    new { Id = Guid.Parse("2222222c-0026-1111-1111-111111111111"), StarsNumber = 1, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("a415a739-5557-4d0e-8980-68bb3ba2aa7e") },
    new { Id = Guid.Parse("1111111c-0027-1111-1111-111111111111"), StarsNumber = 5, Content = "The course was okay, but not engaging.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("32637827-fe2d-4a40-9641-8b18a9df1cfb") },
    new { Id = Guid.Parse("2222222c-0028-1111-1111-111111111111"), StarsNumber = 2, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("32637827-fe2d-4a40-9641-8b18a9df1cfb") },
    new { Id = Guid.Parse("1111111c-0029-1111-1111-111111111111"), StarsNumber = 3, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2") },
    new { Id = Guid.Parse("2222222c-0030-1111-1111-111111111111"), StarsNumber = 5, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2") },
    new { Id = Guid.Parse("1111111c-0031-1111-1111-111111111111"), StarsNumber = 3, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseVariantId = Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178") },
    new { Id = Guid.Parse("2222222c-0032-1111-1111-111111111111"), StarsNumber = 2, Content = "Too fast-paced, but overall good.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseVariantId = Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178") }
);
    }
}
