using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
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

        builder.HasOne(c => c.Participation)
            .WithMany(p => p.Classes)
            .HasForeignKey(c => new { c.UserId, c.CourseId });

        builder.HasMany(c => c.Exercises)
            .WithOne(e => e.Class)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Files)
            .WithMany(f => f.Classes)
            .UsingEntity<Dictionary<string, object>>(
                "ClassFileResources", // nazwa tabeli pośredniczącej
                j => j
                    .HasOne<FileResource>()
                    .WithMany()
                    .HasForeignKey("FileResourceId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Class>()
                    .WithMany()
                    .HasForeignKey("ClassId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("ClassId", "FileResourceId");

                    j.HasData(
                        new
                        {
                            ClassId = Guid.Parse("3b436cdc-53ea-4c80-a947-ca1a7ccc350b"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555553555555")
                        },
                        new
                        {
                            ClassId = Guid.Parse("5e232654-e629-49e3-98c2-4559505165c6"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555553555555")
                        },
                        new
                        {
                            ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555553555555")
                        },
                        new
                        {
                            ClassId = Guid.Parse("653977fd-d020-4c27-90e4-2232412ef2f5"),
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555553555555")
                        }
                    );
                });

        builder.HasMany(c => c.Links)
            .WithOne(l => l.Class)
            .HasForeignKey(l => l.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        var now = new DateTime(2025, 10, 2, 12, 0, 0, DateTimeKind.Utc);
        var classId = Guid.Parse("43333333-3333-3333-3333-333333333333");
        var statusScheduledId = Guid.Parse("41111111-1111-1111-1111-111111111111");
        var student1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");

        builder.HasData(
        new
        {
            Id = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668"),
            StartTime = new DateTime(2025, 12, 6, 5, 49, 42, 70, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/a9666cb3",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("3b436cdc-53ea-4c80-a947-ca1a7ccc350b"),
            StartTime = new DateTime(2026, 1, 27, 4, 22, 22, 106, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/cbfa65d0",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("04806df7-dc2d-481a-ab6a-fcf2be9cc16c"),
            StartTime = new DateTime(2025, 12, 2, 7, 10, 33, 267, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/a054d37f",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("dd03fc90-7914-4c41-901f-feeae24142df"),
            StartTime = new DateTime(2026, 2, 23, 21, 9, 13, 10, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/00c7a653",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("5e232654-e629-49e3-98c2-4559505165c6"),
            StartTime = new DateTime(2025, 10, 18, 2, 27, 9, 371, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/ff9a47e5",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("10761475-fd6f-452f-9817-0f5b11e907a9"),
            StartTime = new DateTime(2026, 3, 6, 7, 13, 23, 304, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/98ac26d0",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("a3c2b920-a1b2-4cd2-8db4-4945b467ce2f"),
            StartTime = new DateTime(2025, 12, 29, 21, 29, 19, 675, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/a14bf451",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("9005a051-a079-4dc2-82b9-f7b3ab128b2f"),
            StartTime = new DateTime(2026, 2, 26, 0, 37, 4, 123, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/1670ac1e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("d0df950c-ad65-4fc0-8e10-64788b75781a"),
            StartTime = new DateTime(2026, 1, 4, 15, 58, 32, 384, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/2e7bca49",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("d3fd515d-c9a8-4a12-ae4b-045d2baaa725"),
            StartTime = new DateTime(2025, 12, 22, 20, 10, 10, 184, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/5c6e203f",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("a9b47a16-dd1a-4d4c-aab5-a2f2156dc72d"),
            StartTime = new DateTime(2026, 1, 21, 5, 36, 14, 400, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/9e8247cb",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("653977fd-d020-4c27-90e4-2232412ef2f5"),
            StartTime = new DateTime(2025, 10, 7, 6, 39, 8, 895, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/105b8671",
            ClassStatusId = Guid.Parse("42222222-2222-2222-2222-222222222222"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("4e6cc8b6-8658-4d3f-81cc-a929feb56ca8"),
            StartTime = new DateTime(2026, 3, 13, 11, 54, 14, 636, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/bd976747",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("c5374e7c-5922-4208-820c-83b7bef81ea8"),
            StartTime = new DateTime(2025, 11, 22, 17, 33, 51, 727, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/1ac62717",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("2c7ddd20-534a-4f7f-a722-909ab0a67aad"),
            StartTime = new DateTime(2025, 10, 11, 1, 13, 45, 899, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/85c8d54f",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("79c9212c-dc94-4f45-aca9-b35eecacc8d2"),
            StartTime = new DateTime(2025, 12, 19, 0, 22, 25, 133, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/95bd18d9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("d539b5bd-da7d-4d50-9f6d-bcee91ef88fb"),
            StartTime = new DateTime(2026, 1, 13, 18, 12, 30, 664, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/18281db6",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("eaf96048-a284-43eb-a1df-c18ab9c0c2c1"),
            StartTime = new DateTime(2026, 3, 20, 15, 3, 1, 185, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/9c1bf982",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("6a505e6f-15c5-45b0-973c-b2ad02388314"),
            StartTime = new DateTime(2026, 3, 8, 7, 43, 35, 723, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/cf149cc0",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("597b6fe3-57e6-4831-a07c-991de998bfe2"),
            StartTime = new DateTime(2026, 1, 24, 6, 27, 0, 391, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/c636a25b",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("5a6b2eb1-25fe-465b-b2ea-56d584528c87"),
            StartTime = new DateTime(2025, 11, 27, 6, 26, 57, 795, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/242c7bfa",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("5f50d51c-ba7f-4bb7-bf3f-88b1c10cbcf0"),
            StartTime = new DateTime(2025, 12, 21, 18, 20, 5, 623, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/8d78c1a9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("1619b967-7450-472f-9ced-a9c4ab701318"),
            StartTime = new DateTime(2025, 12, 27, 0, 1, 42, 986, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/f39e0e2c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("9dc8306e-d10a-473f-8d8c-24b8f04083a8"),
            StartTime = new DateTime(2026, 3, 13, 6, 51, 53, 565, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/8118269e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("166b7349-a733-48e5-bb04-e9f0f5f1eeaf"),
            StartTime = new DateTime(2026, 1, 12, 18, 11, 8, 973, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/87fc2a93",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("fe37a1fd-f344-4940-ade7-bede9b784c78"),
            StartTime = new DateTime(2025, 12, 12, 19, 38, 43, 424, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/fa104442",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("1c617641-f474-4b97-b528-f1e0c2d31ced"),
            StartTime = new DateTime(2025, 11, 20, 21, 20, 30, 637, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/2d7e07fd",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("54231f0d-9be4-4b19-ac3c-307411c36d84"),
            StartTime = new DateTime(2026, 2, 28, 18, 15, 0, 795, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/0f1a6fe0",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("ca7d32b6-8910-4719-9ebf-ec1f79f6b3ab"),
            StartTime = new DateTime(2026, 2, 15, 8, 21, 12, 499, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/ef2895f7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("88176c18-6d5e-4fef-9357-dcf5bb605044"),
            StartTime = new DateTime(2025, 10, 5, 20, 45, 28, 714, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/2b180b96",
            ClassStatusId = Guid.Parse("42222222-2222-2222-2222-222222222222"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("f5839a47-28a6-4335-a4d2-eecfce6a1478"),
            StartTime = new DateTime(2025, 10, 29, 4, 34, 26, 644, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/78968696",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2")
        },
        new
        {
            Id = Guid.Parse("6bda0668-b6d4-4773-b822-e58816df0ebe"),
            StartTime = new DateTime(2026, 1, 13, 2, 42, 35, 539, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/0d9aefb4",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("898a95d6-d2fb-4519-b6ee-fc4928a2831e"),
            StartTime = new DateTime(2026, 1, 10, 10, 20, 16, 429, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/bcf0c5ef",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("4a1ae34b-57bd-4b2c-b25d-2e9c8c5ed4c6"),
            StartTime = new DateTime(2026, 1, 7, 11, 58, 7, 807, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/f856448e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("3a686937-654b-4085-a4cb-91c7e0e79dc9"),
            StartTime = new DateTime(2026, 1, 4, 11, 14, 48, 679, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/3707f5ae",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("25fafe89-827a-4e61-8256-47f7be392839"),
            StartTime = new DateTime(2026, 1, 3, 12, 24, 59, 170, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/7f35fe50",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("55d76dff-5ca6-4d7b-a80d-9a773b574406"),
            StartTime = new DateTime(2025, 12, 5, 9, 20, 51, 631, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/3f7d2aa5",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("40e85018-7490-48b0-8eab-5368d5f73e22"),
            StartTime = new DateTime(2026, 2, 26, 11, 43, 41, 55, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/678b7248",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("8dad9090-9e0f-4629-86d8-b1295bf09b5f"),
            StartTime = new DateTime(2025, 11, 2, 20, 38, 29, 353, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/8a606b9c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
        },
        new
        {
            Id = Guid.Parse("bfbd200d-398b-4789-a002-32ea570134eb"),
            StartTime = new DateTime(2025, 12, 10, 18, 21, 54, 491, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/1ea87f39",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("2e10ef79-df92-4442-879f-f8369864bb7c"),
            StartTime = new DateTime(2025, 10, 23, 11, 22, 41, 642, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/fb2f5dbb",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("a4298748-5898-4089-9a00-cb6ca340f62a"),
            StartTime = new DateTime(2025, 12, 25, 23, 52, 50, 564, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/c0bc42e4",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
        },
        new
        {
            Id = Guid.Parse("dfac9b08-8ef5-4476-a59c-735b2d58f3bd"),
            StartTime = new DateTime(2026, 3, 28, 9, 33, 59, 397, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/c8a3cac8",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("8b58f091-a67b-417d-a972-3e3d95549a2f"),
            StartTime = new DateTime(2026, 1, 2, 20, 5, 59, 33, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/29ca5b42",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("55070d2d-5a26-4455-99a6-024fc3a33352"),
            StartTime = new DateTime(2025, 10, 24, 9, 21, 17, 178, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/3ba7c22d",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("809377e4-4e50-4f00-92e2-fae20a9ce4d4"),
            StartTime = new DateTime(2025, 12, 14, 13, 9, 16, 233, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/7b436c63",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("dc3db657-3dba-42da-af80-e9f2195e781a"),
            StartTime = new DateTime(2026, 1, 8, 6, 4, 26, 634, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/bebeea43",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("2a9cc83b-cb2c-4b30-a149-9886736ae4ce"),
            StartTime = new DateTime(2025, 10, 27, 0, 50, 39, 392, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/162a96c2",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("4d93311e-5e96-41e3-8b56-7035de6b7000"),
            StartTime = new DateTime(2025, 12, 13, 20, 16, 35, 608, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/2cb6822d",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("9f5ff908-4a04-446a-860c-320e81cc4984"),
            StartTime = new DateTime(2025, 12, 31, 8, 25, 26, 410, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/b39950b1",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("430ff2e4-5dc8-4ea2-a8f7-fa2724ae2abc"),
            StartTime = new DateTime(2026, 3, 3, 14, 39, 56, 837, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/f6c3e123",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("ddd176d0-9f6d-427a-9bf5-ad77affdcde8"),
            StartTime = new DateTime(2025, 12, 18, 2, 25, 52, 46, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/63e1faea",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("4ba510cc-fc36-4893-90fd-487ee685f2f2"),
            StartTime = new DateTime(2026, 1, 30, 6, 24, 4, 96, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/5db93847",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("c292103f-31ff-44cc-9eb6-3e43e97b1dfd"),
            StartTime = new DateTime(2025, 11, 5, 18, 21, 22, 912, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/730d49b1",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("bd5f6e6d-b411-4ffc-a4fd-5bd3cc52109c"),
            StartTime = new DateTime(2025, 12, 4, 17, 15, 41, 551, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/b70659d6",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("bc146c66-85f0-4d8e-94bc-d9bdaeb6f1c4"),
            StartTime = new DateTime(2026, 2, 13, 12, 32, 21, 730, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/236eb9c0",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("19818eae-8429-4cf2-9a82-2adc088b736c"),
            StartTime = new DateTime(2026, 1, 23, 10, 54, 32, 698, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/50910c9b",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
        },
        new
        {
            Id = Guid.Parse("c486d965-2093-4e4a-a2ae-c3f9fb0a7b8c"),
            StartTime = new DateTime(2026, 2, 16, 2, 38, 40, 273, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/c85ed656",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("92eca9bb-eee1-46c1-8b0b-d65dcb5cda87"),
            StartTime = new DateTime(2026, 1, 22, 21, 54, 15, 800, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/07b372f5",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("08e9c9b4-5f4c-4886-a7f4-1c04c4ca0e9d"),
            StartTime = new DateTime(2026, 1, 23, 10, 5, 33, 447, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/4076a3d7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("f8190291-dccf-4321-8e66-a13e616df8de"),
            StartTime = new DateTime(2026, 1, 17, 3, 35, 47, 445, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/670f9787",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("bf18c4d2-fcc3-429c-9ed1-afaffc613185"),
            StartTime = new DateTime(2025, 11, 11, 3, 11, 27, 281, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/e1cb7dd7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("5483e82e-1dab-4d1e-8142-f6f7a4b61be0"),
            StartTime = new DateTime(2026, 1, 29, 4, 50, 14, 386, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/2162dcc9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("2988615a-e919-4555-94fc-1dad57bb1897"),
            StartTime = new DateTime(2026, 2, 7, 15, 11, 16, 169, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/630e3cbb",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("8443a682-f3f4-4670-90af-3d636655ad12"),
            StartTime = new DateTime(2025, 11, 14, 0, 45, 49, 351, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/905cac16",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("9572378c-e4a2-4d05-85de-d02b8238fd2b"),
            StartTime = new DateTime(2025, 10, 11, 21, 44, 54, 840, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/7b2b8c33",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("e85e13df-ffd8-40c8-866c-8a3d5b62c968"),
            StartTime = new DateTime(2026, 3, 9, 8, 24, 30, 492, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/59ef06f9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
        },
        new
        {
            Id = Guid.Parse("590d47c9-8af0-4c54-8156-16ce670b8670"),
            StartTime = new DateTime(2025, 10, 20, 2, 53, 32, 170, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/24791226",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("db6f11c4-101b-4fde-bec0-defd8b52319f"),
            StartTime = new DateTime(2026, 3, 20, 0, 55, 47, 112, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/0d62be16",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("6346be9b-73c4-4746-86a5-435fc4eaad56"),
            StartTime = new DateTime(2026, 2, 7, 10, 45, 32, 119, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/fb8032de",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("da1c74b4-8217-4eb6-b266-ef7f047821e5"),
            StartTime = new DateTime(2025, 12, 1, 23, 52, 1, 637, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/77b1c858",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("8053903f-146d-4795-931c-f802e8628cbd"),
            StartTime = new DateTime(2026, 1, 29, 10, 57, 28, 803, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/bf7cf7af",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("36cb7cd3-dd52-437e-8848-d86cb4b77067"),
            StartTime = new DateTime(2026, 2, 17, 21, 20, 58, 158, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/6a861127",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("e57a98d4-f256-4893-a19d-3e3b2aedbcaf"),
            StartTime = new DateTime(2025, 12, 13, 7, 18, 52, 740, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/66c1cefd",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("9c8b9a86-bc44-47ae-a5d6-bcbd930b9eb8"),
            StartTime = new DateTime(2025, 11, 4, 0, 39, 43, 640, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/b04e01e7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("8cf5c033-1abf-4a96-8249-ad591b102dfc"),
            StartTime = new DateTime(2026, 1, 30, 5, 39, 50, 194, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/9721f6ca",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("73334b7a-28cc-425e-acc0-5aa301426eed"),
            StartTime = new DateTime(2025, 10, 10, 0, 34, 58, 263, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/fa0ebeca",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("c0091f46-622e-4e4d-a05a-12dcaf05c263"),
            StartTime = new DateTime(2026, 2, 10, 20, 57, 19, 219, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/c864fa15",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("cab65f21-eb52-4d41-8d04-6da23bc5a20b"),
            StartTime = new DateTime(2025, 11, 25, 22, 45, 2, 343, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/47db2e8d",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("f4ada7e9-9036-4e3b-86a1-1cffcd78ee72"),
            StartTime = new DateTime(2025, 12, 17, 5, 24, 30, 149, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/2cfa0081",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("98cea40f-9cce-4266-b678-1d47ed1c7f1b"),
            StartTime = new DateTime(2025, 11, 6, 4, 50, 32, 522, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/b00e0b15",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("72df1f95-9af5-49c0-97f3-50f4bffee160"),
            StartTime = new DateTime(2026, 3, 11, 7, 9, 5, 293, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/db2a3731",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2")
        },
        new
        {
            Id = Guid.Parse("f4fda6f5-96b8-4195-bc5b-944b34523e56"),
            StartTime = new DateTime(2025, 10, 21, 12, 57, 58, 754, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/2f623547",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("41668901-3476-4573-8230-7ba6cad7ad61"),
            StartTime = new DateTime(2025, 12, 14, 20, 47, 59, 19, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/5533ead9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40")
        },
        new
        {
            Id = Guid.Parse("ccdbf889-4c34-48dc-8abf-f5701bc03a9e"),
            StartTime = new DateTime(2026, 1, 15, 5, 43, 23, 196, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/0fc8b57e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("ce2d8ca1-6f3c-44ac-9207-529f19ace3d7"),
            StartTime = new DateTime(2026, 2, 15, 19, 16, 26, 267, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/a9f12556",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("5075c7e1-5257-4b40-82b4-b974952aa15f"),
            StartTime = new DateTime(2025, 10, 26, 11, 8, 22, 701, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/a4c0902a",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("23acbb91-af14-4f83-961f-80051c1f2a43"),
            StartTime = new DateTime(2025, 11, 12, 6, 19, 5, 8, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/42d1a1df",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("eb09b8ac-f801-44ff-85dd-6f63f6213603"),
            StartTime = new DateTime(2026, 1, 18, 8, 58, 38, 889, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/ded06c9f",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("3b1efa1b-cb60-4230-9085-7cde01984986"),
            StartTime = new DateTime(2026, 1, 3, 9, 13, 38, 212, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/b6655450",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("febe3e4e-84d9-429b-aedf-bf2b9d9a9533"),
            StartTime = new DateTime(2026, 2, 14, 10, 55, 52, 369, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/b3441c04",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("4e1f6047-c688-4ef9-bf9f-89ac6e082c55"),
            StartTime = new DateTime(2026, 3, 31, 13, 34, 8, 506, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/71859e9d",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("d27a0610-ad56-4f71-9615-45567d68ab36"),
            StartTime = new DateTime(2025, 12, 13, 5, 9, 40, 214, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/755651d7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("376af187-37fb-4da2-bc48-3ab25c514214"),
            StartTime = new DateTime(2025, 10, 26, 12, 28, 51, 866, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/0c30af04",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
        },
        new
        {
            Id = Guid.Parse("8c811295-5397-4967-acb2-09cdd24140ec"),
            StartTime = new DateTime(2026, 3, 7, 2, 46, 8, 931, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/cd36a53d",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("bb271e47-7532-4488-8c9b-84856e35de10"),
            StartTime = new DateTime(2025, 12, 25, 0, 22, 39, 40, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/b3c7ab84",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("92b32a02-4244-4271-a8b0-177813151695"),
            StartTime = new DateTime(2025, 11, 2, 22, 34, 50, 1, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/2fb751fa",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("4b42d48d-2112-4ec8-a55f-b074c6fce4d4"),
            StartTime = new DateTime(2025, 10, 24, 19, 57, 54, 399, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/b05e6bb3",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("110af0ea-b9be-470b-aef4-4fbb93176612"),
            StartTime = new DateTime(2026, 1, 21, 0, 12, 58, 133, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/27b87acd",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("9462cb25-3418-4fa0-9a84-b440cdcadab1"),
            StartTime = new DateTime(2026, 2, 9, 10, 58, 52, 236, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/f53e2570",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
        },
        new
        {
            Id = Guid.Parse("56e6affb-1bf8-4953-b14e-0899824125ac"),
            StartTime = new DateTime(2025, 11, 11, 8, 18, 59, 681, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/c92c60d4",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("28c7b1bb-7581-4a84-9b75-3cf3b3e27065"),
            StartTime = new DateTime(2025, 12, 14, 15, 45, 23, 527, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/d71a7b73",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15")
        },
        new
        {
            Id = Guid.Parse("8bcbc7f6-1582-43ea-bcdb-939af645e696"),
            StartTime = new DateTime(2026, 2, 24, 12, 34, 58, 279, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/75ca8c99",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("37b1a441-f32a-4b9c-a5f4-88cfbc29def1"),
            StartTime = new DateTime(2026, 2, 5, 4, 3, 6, 302, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/f264fbd9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
        },
        new
        {
            Id = Guid.Parse("22010015-d84b-42f4-86ce-b543d315d4cc"),
            StartTime = new DateTime(2025, 12, 14, 23, 46, 12, 833, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/5ae86199",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("5a96d050-90f7-41b3-bc8d-ad8ac2213455"),
            StartTime = new DateTime(2026, 1, 26, 2, 8, 8, 782, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/515753f9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("2381c734-4ebd-4c73-84a1-205bec548788"),
            StartTime = new DateTime(2026, 2, 7, 8, 48, 3, 685, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/befe5d53",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("21deedff-73f7-44b9-af4e-faf877677023"),
            StartTime = new DateTime(2025, 10, 17, 9, 21, 49, 396, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/ecd10ec7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("fa6be8be-f2dd-4f5c-a700-5ef9af7cf28a"),
            StartTime = new DateTime(2025, 10, 8, 10, 54, 34, 831, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/22fe52f6",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("bae6f4fa-502b-482c-94c4-a10a025b0600"),
            StartTime = new DateTime(2025, 12, 9, 21, 12, 11, 864, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/33528b3c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("cd4e5bf4-8bee-48fb-91f3-8a544024c90c"),
            StartTime = new DateTime(2025, 10, 24, 3, 32, 58, 451, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/73f6e31e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("1fd4ce1c-ffcf-4046-b2e4-16dfcb025dd6"),
            StartTime = new DateTime(2025, 11, 18, 8, 49, 22, 234, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/1bd81078",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0")
        },
        new
        {
            Id = Guid.Parse("2980c5de-ed0b-4115-9610-0688ab9ec4b5"),
            StartTime = new DateTime(2025, 11, 15, 12, 4, 22, 793, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/92f8e808",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("1d8eedb2-9518-49b3-b484-a9e11af14b43"),
            StartTime = new DateTime(2025, 12, 4, 20, 7, 57, 635, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/65a3bf23",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("ef743714-1f09-4c80-a295-9c112e0c2cd6"),
            StartTime = new DateTime(2026, 1, 20, 3, 25, 52, 840, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/dac9f27b",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
        },
        new
        {
            Id = Guid.Parse("f91cba7a-e43f-4233-8b1d-a8085eca1720"),
            StartTime = new DateTime(2026, 1, 14, 7, 36, 29, 1, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/e2079979",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
        },
        new
        {
            Id = Guid.Parse("71a3d40e-7bb8-4a3f-b89c-9a465e1dd56a"),
            StartTime = new DateTime(2026, 2, 6, 6, 31, 46, 42, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/bf95142c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("74680039-27eb-4e40-b55e-23edf4c60328"),
            StartTime = new DateTime(2026, 3, 26, 12, 58, 14, 219, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/a1a36e9c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c")
        },
        new
        {
            Id = Guid.Parse("64de3b52-e261-4152-81fd-f1d74e3f7046"),
            StartTime = new DateTime(2026, 1, 15, 8, 56, 56, 352, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/5c7da5e7",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
        },
        new
        {
            Id = Guid.Parse("52506048-8fcd-4346-96b6-214f370e6b53"),
            StartTime = new DateTime(2025, 12, 28, 7, 47, 14, 660, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/f56a386d",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("4b57edca-127b-4497-875f-114bad7c3856"),
            StartTime = new DateTime(2026, 1, 8, 21, 58, 0, 531, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/384d5e55",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("b825d6bd-c958-4126-8d0d-c90f3e23786d"),
            StartTime = new DateTime(2026, 3, 8, 12, 27, 55, 441, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/4271b32e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("21eb18a4-4262-481b-8cf2-bf16dec017a8"),
            StartTime = new DateTime(2026, 2, 18, 17, 1, 8, 181, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/381eb402",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("71a66cfa-1fa5-4bd1-affa-dd48e489f3d4"),
            StartTime = new DateTime(2026, 2, 15, 21, 16, 57, 723, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/a60636a9",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("1991ad93-cb8e-4b13-9aa3-cb0ab8b03d63"),
            StartTime = new DateTime(2025, 11, 23, 16, 5, 58, 333, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/fd79bae8",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("4d1b3a95-0362-47c1-a014-9bcbac6a4d94"),
            StartTime = new DateTime(2025, 12, 24, 16, 53, 49, 761, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/3c08b968",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("5d0fa399-05ed-46e4-ae17-6d4733c80660"),
            StartTime = new DateTime(2026, 2, 10, 3, 4, 46, 676, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/1c2242ce",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f")
        },
        new
        {
            Id = Guid.Parse("37157991-98d4-4813-a465-1fdfc14c4223"),
            StartTime = new DateTime(2025, 12, 5, 6, 44, 40, 13, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/c70ba7f4",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("fdbdf55c-83d4-487c-b076-2fc0f5d43dc5"),
            StartTime = new DateTime(2026, 2, 2, 14, 1, 54, 803, DateTimeKind.Utc),
            Comment = "Deep dive into key concepts",
            LinkToMeeting = "https://example.com/meeting/f2c48858",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("940a3b5b-df1e-42c6-a6d3-f5245b7cb906"),
            StartTime = new DateTime(2025, 11, 19, 10, 56, 43, 792, DateTimeKind.Utc),
            Comment = "Concept reinforcement",
            LinkToMeeting = "https://example.com/meeting/8668096a",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("af2e3f3b-7d87-4834-8375-e2cbb87fac0c"),
            StartTime = new DateTime(2026, 2, 14, 14, 41, 34, 905, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/67e9ccc3",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("4120596a-c73f-4bfc-800e-2c5af16d7358"),
            StartTime = new DateTime(2026, 3, 9, 5, 15, 56, 744, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/264bc52c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("98f91a97-26ff-43c2-a43a-710484d60456"),
            StartTime = new DateTime(2026, 1, 17, 12, 26, 34, 47, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/e5c3f780",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("e6c52897-0214-4739-8f04-b35f62f07350"),
            StartTime = new DateTime(2026, 3, 28, 0, 43, 52, 256, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/aad383f5",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("3a6325f4-3044-4544-98e8-d6c9600d2d8b"),
            StartTime = new DateTime(2026, 1, 10, 23, 25, 44, 80, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/604bc72e",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("c010c4d1-28aa-41fb-bfc6-8680cf5ebdfe"),
            StartTime = new DateTime(2026, 3, 25, 22, 49, 35, 581, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/a719b848",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3")
        },
        new
        {
            Id = Guid.Parse("5c106a9c-8949-481b-adca-52395821e400"),
            StartTime = new DateTime(2026, 1, 10, 6, 14, 52, 516, DateTimeKind.Utc),
            Comment = "Practice problems",
            LinkToMeeting = "https://example.com/meeting/64d9eb32",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("9d186474-9046-4b72-b1e5-2b727d6bbcaf"),
            StartTime = new DateTime(2025, 10, 25, 22, 6, 6, 762, DateTimeKind.Utc),
            Comment = "Homework review",
            LinkToMeeting = "https://example.com/meeting/b52c95fe",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("1f274284-fee3-4120-a556-7e21e7269216"),
            StartTime = new DateTime(2025, 11, 2, 20, 13, 29, 979, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/772e8415",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("264bb48f-1a05-4013-9f67-b89478dc22b0"),
            StartTime = new DateTime(2026, 3, 5, 19, 21, 39, 728, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/edee693f",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        },
        new
        {
            Id = Guid.Parse("d769195a-da0a-439c-9d21-60354e16cee2"),
            StartTime = new DateTime(2025, 12, 19, 2, 36, 38, 370, DateTimeKind.Utc),
            Comment = "Exam prep session",
            LinkToMeeting = "https://example.com/meeting/3981b1aa",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71")
        },
        new
        {
            Id = Guid.Parse("2340f7d5-6977-4d58-988e-d04aa780a6de"),
            StartTime = new DateTime(2026, 2, 22, 21, 12, 3, 297, DateTimeKind.Utc),
            Comment = "Continue topic",
            LinkToMeeting = "https://example.com/meeting/1fc8aad1",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0")
        },
        new
        {
            Id = Guid.Parse("037a8b17-7aa8-47b4-860c-5632aff0af18"),
            StartTime = new DateTime(2025, 10, 23, 12, 54, 42, 102, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/4429e33c",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6")
        },
        new
        {
            Id = Guid.Parse("b24ad846-5f18-452a-be71-8700f9dbb4aa"),
            StartTime = new DateTime(2025, 12, 20, 6, 26, 41, 539, DateTimeKind.Utc),
            Comment = "Wrap-up & next steps",
            LinkToMeeting = "https://example.com/meeting/5d2b72fd",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90")
        },
        new
        {
            Id = Guid.Parse("f7cfc20c-93a3-475d-86a2-b8e85b8c67fe"),
            StartTime = new DateTime(2026, 2, 17, 15, 35, 15, 761, DateTimeKind.Utc),
            Comment = "Project progress check",
            LinkToMeeting = "https://example.com/meeting/b2141971",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d")
        },
        new
        {
            Id = Guid.Parse("83ef5ead-64c6-474f-b5fb-8be4f8dfa6bd"),
            StartTime = new DateTime(2025, 10, 25, 10, 31, 18, 964, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/8be82956",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb")
        },
        new
        {
            Id = Guid.Parse("5a155f6c-d51e-47ad-a85b-ee822b4cda07"),
            StartTime = new DateTime(2025, 12, 23, 2, 10, 47, 141, DateTimeKind.Utc),
            Comment = "Revision and Q&A",
            LinkToMeeting = "https://example.com/meeting/bbf96d99",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd")
        },
        new
        {
            Id = Guid.Parse("bd98eeae-5a92-40c1-b541-8c736ff0f6fe"),
            StartTime = new DateTime(2025, 11, 1, 9, 41, 28, 555, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/e9f6b81a",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("d5665dc7-79cd-4752-94a5-655fb2bca54d"),
            StartTime = new DateTime(2026, 1, 12, 7, 10, 52, 417, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/f4540c46",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871")
        },
        new
        {
            Id = Guid.Parse("7578f973-8b58-4df2-9372-8b9a2e6bd2ca"),
            StartTime = new DateTime(2025, 12, 10, 3, 57, 8, 73, DateTimeKind.Utc),
            Comment = "Follow-up tasks",
            LinkToMeeting = "https://example.com/meeting/9238a4f8",
            ClassStatusId = Guid.Parse("41111111-1111-1111-1111-111111111111"),
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8")
        }
);
    }
}