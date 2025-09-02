using e_learning_backend.Domain.Participations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.StarsNumber).IsRequired();
        builder.Property(r => r.Content).IsRequired().HasMaxLength(1000);

builder.HasData(
    new { Id = Guid.Parse("1111111c-0001-1111-1111-111111111111"), StarsNumber = 1, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871") },
    new { Id = Guid.Parse("2222222c-0002-1111-1111-111111111111"), StarsNumber = 3, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871") },
    new { Id = Guid.Parse("1111111c-0003-1111-1111-111111111111"), StarsNumber = 5, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90") },
    new { Id = Guid.Parse("2222222c-0004-1111-1111-111111111111"), StarsNumber = 5, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90") },
    new { Id = Guid.Parse("1111111c-0005-1111-1111-111111111111"), StarsNumber = 5, Content = "Instructor was very clear and supportive.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd") },
    new { Id = Guid.Parse("2222222c-0006-1111-1111-111111111111"), StarsNumber = 5, Content = "Instructor was very clear and supportive.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd") },
    new { Id = Guid.Parse("1111111c-0007-1111-1111-111111111111"), StarsNumber = 2, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0") },
    new { Id = Guid.Parse("2222222c-0008-1111-1111-111111111111"), StarsNumber = 3, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0") },
    new { Id = Guid.Parse("1111111c-0009-1111-1111-111111111111"), StarsNumber = 3, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d") },
    new { Id = Guid.Parse("2222222c-0010-1111-1111-111111111111"), StarsNumber = 5, Content = "Instructor was very clear and supportive.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d") },
    new { Id = Guid.Parse("1111111c-0011-1111-1111-111111111111"), StarsNumber = 1, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6") },
    new { Id = Guid.Parse("2222222c-0012-1111-1111-111111111111"), StarsNumber = 4, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6") },
    new { Id = Guid.Parse("1111111c-0013-1111-1111-111111111111"), StarsNumber = 4, Content = "The course was okay, but not engaging.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2") },
    new { Id = Guid.Parse("2222222c-0014-1111-1111-111111111111"), StarsNumber = 4, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2") },
    new { Id = Guid.Parse("1111111c-0015-1111-1111-111111111111"), StarsNumber = 3, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3") },
    new { Id = Guid.Parse("2222222c-0016-1111-1111-111111111111"), StarsNumber = 5, Content = "Great course, learned a lot!", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3") },
    new { Id = Guid.Parse("1111111c-0017-1111-1111-111111111111"), StarsNumber = 3, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71") },
    new { Id = Guid.Parse("2222222c-0018-1111-1111-111111111111"), StarsNumber = 2, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71") },
    new { Id = Guid.Parse("1111111c-0019-1111-1111-111111111111"), StarsNumber = 1, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40") },
    new { Id = Guid.Parse("2222222c-0020-1111-1111-111111111111"), StarsNumber = 1, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40") },
    new { Id = Guid.Parse("1111111c-0021-1111-1111-111111111111"), StarsNumber = 3, Content = "Excellent explanations, highly recommend.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8") },
    new { Id = Guid.Parse("2222222c-0022-1111-1111-111111111111"), StarsNumber = 2, Content = "Content was a bit difficult but useful.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8") },
    new { Id = Guid.Parse("1111111c-0023-1111-1111-111111111111"), StarsNumber = 4, Content = "The course was okay, but not engaging.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15") },
    new { Id = Guid.Parse("2222222c-0024-1111-1111-111111111111"), StarsNumber = 2, Content = "Helpful course, but could be more detailed.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15") },
    new { Id = Guid.Parse("1111111c-0025-1111-1111-111111111111"), StarsNumber = 1, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f") },
    new { Id = Guid.Parse("2222222c-0026-1111-1111-111111111111"), StarsNumber = 1, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f") },
    new { Id = Guid.Parse("1111111c-0027-1111-1111-111111111111"), StarsNumber = 5, Content = "The course was okay, but not engaging.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c") },
    new { Id = Guid.Parse("2222222c-0028-1111-1111-111111111111"), StarsNumber = 2, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c") },
    new { Id = Guid.Parse("1111111c-0029-1111-1111-111111111111"), StarsNumber = 3, Content = "Good introduction, but needs more depth.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb") },
    new { Id = Guid.Parse("2222222c-0030-1111-1111-111111111111"), StarsNumber = 5, Content = "I loved the practical examples.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb") },
    new { Id = Guid.Parse("1111111c-0031-1111-1111-111111111111"), StarsNumber = 3, Content = "Amazing experience, learned new skills.", ParticipationUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ParticipationCourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0") },
    new { Id = Guid.Parse("2222222c-0032-1111-1111-111111111111"), StarsNumber = 2, Content = "Too fast-paced, but overall good.", ParticipationUserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), ParticipationCourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0") }
);
    }
}
