namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FileResourceEntityTypeConfiguration : IEntityTypeConfiguration<FileResource>
{
    public void Configure(EntityTypeBuilder<FileResource> builder)
    {
        builder.HasKey(fr => fr.Id);

        builder.Property(fr => fr.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(fr => fr.Path)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(fr => fr.AddedAt)
            .IsRequired();

        builder.HasOne(fr => fr.User)
            .WithMany(u => u.Files)
            .HasForeignKey(fr => fr.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new
            {
                Id = Guid.Parse("ff555555-5555-5555-5555-555553555555"),
                Name = "example.pdf",
                Path = "/uploads/example.pdf",
                AddedAt = new DateTime(2025, 7, 11, 10, 0, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("f8ce2cd8-0647-47e1-a70f-fad73e30e123"),
                Name = "Performance Review 18.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/f8ce2cd8-0647-47e1-a70f-fad73e30e123.pptx",
                AddedAt = new DateTime(2024, 3, 10, 6, 46, 17, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("70f94315-d6c1-415d-b327-57430ee490c6"),
                Name = "System Design 19.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/70f94315-d6c1-415d-b327-57430ee490c6.png",
                AddedAt = new DateTime(2025, 11, 16, 21, 8, 33, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4c6f3dc2-336c-4821-9063-05ba8e884165"),
                Name = "Team Overview 1.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/4c6f3dc2-336c-4821-9063-05ba8e884165.docx",
                AddedAt = new DateTime(2024, 5, 19, 0, 36, 56, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("540f91e0-9c31-40d6-a7ba-a8efd0bb46cf"),
                Name = "Procurement Request 16.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/540f91e0-9c31-40d6-a7ba-a8efd0bb46cf.xlsx",
                AddedAt = new DateTime(2025, 3, 3, 4, 29, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("6dea5272-3ed0-4f6a-bd18-5d6b8168c516"),
                Name = "Testing Checklist 3.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/6dea5272-3ed0-4f6a-bd18-5d6b8168c516.xlsx",
                AddedAt = new DateTime(2024, 1, 23, 16, 10, 38, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("c705a4ab-ccba-41c7-a5ae-dc67a32d46b7"),
                Name = "Operational Report 13.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/c705a4ab-ccba-41c7-a5ae-dc67a32d46b7.txt",
                AddedAt = new DateTime(2025, 6, 22, 6, 45, 20, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("7383a95b-961e-4b88-9a3a-7edb9c2b5bff"),
                Name = "Training Handbook 18.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/7383a95b-961e-4b88-9a3a-7edb9c2b5bff.pdf",
                AddedAt = new DateTime(2025, 8, 21, 14, 31, 21, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("681c0181-9d7a-4ec5-b179-ee9eb40ec018"),
                Name = "Prototype Layout 2.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/681c0181-9d7a-4ec5-b179-ee9eb40ec018.docx",
                AddedAt = new DateTime(2024, 2, 20, 14, 11, 4, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4f9c957e-022c-4e5e-be47-08a1f9915336"),
                Name = "Payroll Report 8.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/4f9c957e-022c-4e5e-be47-08a1f9915336.pdf",
                AddedAt = new DateTime(2024, 5, 9, 10, 57, 31, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("06692afa-8e02-4074-81e7-232d9c7c3beb"),
                Name = "Feature Description 7.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/06692afa-8e02-4074-81e7-232d9c7c3beb.pptx",
                AddedAt = new DateTime(2025, 3, 22, 1, 19, 54, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("70dcd2b3-bc6b-4e74-b467-a8fa3b5bf571"),
                Name = "Kubernetes Config 15.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/70dcd2b3-bc6b-4e74-b467-a8fa3b5bf571.txt",
                AddedAt = new DateTime(2024, 10, 25, 2, 19, 28, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("184d4224-07b8-4045-b8d1-08c6055aa480"),
                Name = "Task List 18.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/184d4224-07b8-4045-b8d1-08c6055aa480.txt",
                AddedAt = new DateTime(2024, 2, 14, 7, 2, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("02ec10f6-92ef-4095-96b6-244db10924e0"),
                Name = "Reference Sheet 18.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/02ec10f6-92ef-4095-96b6-244db10924e0.txt",
                AddedAt = new DateTime(2025, 4, 5, 12, 26, 15, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("66d08c8d-2c0d-46d8-9e5d-64da20c354b4"),
                Name = "Training Handbook 19.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/66d08c8d-2c0d-46d8-9e5d-64da20c354b4.pdf",
                AddedAt = new DateTime(2025, 8, 18, 4, 23, 7, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("ee7a2d96-8cf4-49f9-b92a-f729c525e6c4"),
                Name = "Training Handbook 20.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/ee7a2d96-8cf4-49f9-b92a-f729c525e6c4.pptx",
                AddedAt = new DateTime(2024, 9, 19, 2, 58, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("1806c3a4-10b3-4710-8101-c8bee54c5260"),
                Name = "Lecture Summary 1.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/1806c3a4-10b3-4710-8101-c8bee54c5260.xlsx",
                AddedAt = new DateTime(2024, 11, 30, 1, 47, 27, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("484dbaec-d078-48b2-8b59-2a2255dc9c8d"),
                Name = "Client Notes 20.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/484dbaec-d078-48b2-8b59-2a2255dc9c8d.pdf",
                AddedAt = new DateTime(2024, 10, 18, 20, 4, 57, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("09ceba9f-1e38-4f3d-ad99-13f9dd962c47"),
                Name = "Docker Blueprint 4.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/09ceba9f-1e38-4f3d-ad99-13f9dd962c47.pdf",
                AddedAt = new DateTime(2025, 9, 18, 15, 47, 33, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("7e845b9d-c2a9-4c59-97de-892a4ac387d9"),
                Name = "Employee Handbook 12.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/7e845b9d-c2a9-4c59-97de-892a4ac387d9.txt",
                AddedAt = new DateTime(2025, 10, 30, 1, 37, 12, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("08db0c26-12a8-4820-ad0f-f202b3975808"),
                Name = "Annual Summary 10.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/08db0c26-12a8-4820-ad0f-f202b3975808.png",
                AddedAt = new DateTime(2024, 12, 24, 8, 26, 47, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("530c76c7-3499-4317-ab8e-bd6c8064069e"),
                Name = "Project Notes 16.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/530c76c7-3499-4317-ab8e-bd6c8064069e.txt",
                AddedAt = new DateTime(2024, 10, 16, 10, 3, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("cb73e98e-b15c-468c-8b54-e6f30520d913"),
                Name = "Procurement Request 12.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/cb73e98e-b15c-468c-8b54-e6f30520d913.png",
                AddedAt = new DateTime(2024, 2, 16, 11, 55, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("efa2962d-00f7-4ad7-a876-48580001842a"),
                Name = "Performance Report 17.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/efa2962d-00f7-4ad7-a876-48580001842a.png",
                AddedAt = new DateTime(2025, 10, 31, 16, 54, 16, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("9773566f-d117-4aa8-914f-206f03bf8bbc"),
                Name = "Beta Feedback 6.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/9773566f-d117-4aa8-914f-206f03bf8bbc.pdf",
                AddedAt = new DateTime(2025, 11, 12, 3, 8, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("f850d2a0-401a-42d0-b7d6-3b48f3d521e6"),
                Name = "Cloud Policy 13.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/f850d2a0-401a-42d0-b7d6-3b48f3d521e6.docx",
                AddedAt = new DateTime(2025, 9, 19, 7, 8, 3, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("455b0128-5ed5-414c-a6fd-3aebb9ad4c64"),
                Name = "Hiring Form 3.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/455b0128-5ed5-414c-a6fd-3aebb9ad4c64.pdf",
                AddedAt = new DateTime(2024, 5, 30, 1, 18, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("e704d8e8-8ec0-46a4-b8c3-4311817edb07"),
                Name = "Quiz Material 20.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/e704d8e8-8ec0-46a4-b8c3-4311817edb07.docx",
                AddedAt = new DateTime(2024, 12, 12, 1, 14, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("3508750f-9aa2-451b-a904-195d2d7b865d"),
                Name = "Learning Worksheet 3.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/3508750f-9aa2-451b-a904-195d2d7b865d.pdf",
                AddedAt = new DateTime(2024, 11, 24, 4, 1, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("71886ca9-0934-4366-b024-05b09eb1786f"),
                Name = "Pipeline Script 5.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/71886ca9-0934-4366-b024-05b09eb1786f.pdf",
                AddedAt = new DateTime(2025, 4, 14, 17, 16, 59, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("ad5b265f-2785-4adf-82d5-9c9953f353e7"),
                Name = "Internal Memo 14.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/ad5b265f-2785-4adf-82d5-9c9953f353e7.pptx",
                AddedAt = new DateTime(2024, 2, 23, 0, 49, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("f3b859b2-6d5f-4454-af38-be31d3136a2b"),
                Name = "Feature Description 5.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/f3b859b2-6d5f-4454-af38-be31d3136a2b.txt",
                AddedAt = new DateTime(2025, 5, 4, 18, 12, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("bcd14879-7cea-428a-b05f-27937fad0227"),
                Name = "Product Overview 2.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/bcd14879-7cea-428a-b05f-27937fad0227.pdf",
                AddedAt = new DateTime(2024, 10, 28, 5, 28, 15, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("9b23217d-dc5b-47f9-a5a1-bc290a926dea"),
                Name = "Crash Report 9.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/9b23217d-dc5b-47f9-a5a1-bc290a926dea.png",
                AddedAt = new DateTime(2025, 8, 16, 7, 16, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("b6956ae6-a1e5-46e4-b9c7-c1809bf8af6d"),
                Name = "Internal Memo 3.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/b6956ae6-a1e5-46e4-b9c7-c1809bf8af6d.txt",
                AddedAt = new DateTime(2024, 10, 25, 19, 48, 40, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("5be6383f-b726-427e-85a6-66f5365e66d2"),
                Name = "Medical Form 15.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/5be6383f-b726-427e-85a6-66f5365e66d2.pdf",
                AddedAt = new DateTime(2024, 3, 12, 8, 58, 42, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("744dc886-d2b2-4138-970b-46ed880e1c69"),
                Name = "Design Draft 16.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/744dc886-d2b2-4138-970b-46ed880e1c69.xlsx",
                AddedAt = new DateTime(2024, 9, 21, 16, 15, 41, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a85a21fd-8eb5-45e0-b33e-30cf35c82d9a"),
                Name = "Briefing 16.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/a85a21fd-8eb5-45e0-b33e-30cf35c82d9a.docx",
                AddedAt = new DateTime(2024, 5, 26, 15, 23, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("0daa2725-4723-4d23-a2b7-a0cc78beb358"),
                Name = "Deployment Plan 12.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/0daa2725-4723-4d23-a2b7-a0cc78beb358.pptx",
                AddedAt = new DateTime(2025, 5, 14, 9, 12, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("ab5adb07-1292-49d4-8fed-109fd46f15e5"),
                Name = "Overview 19.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/ab5adb07-1292-49d4-8fed-109fd46f15e5.png",
                AddedAt = new DateTime(2024, 3, 9, 6, 15, 47, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("b4a8d4ce-85bc-4369-9b09-6f56ad52bbc9"),
                Name = "General Notes 15.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/b4a8d4ce-85bc-4369-9b09-6f56ad52bbc9.xlsx",
                AddedAt = new DateTime(2025, 4, 8, 7, 46, 3, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4f95d674-b2e2-479a-98ae-bfdf3913870a"),
                Name = "Encryption Guide 2.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/4f95d674-b2e2-479a-98ae-bfdf3913870a.pdf",
                AddedAt = new DateTime(2025, 9, 26, 19, 16, 22, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("a9b16505-c50a-4d7b-99d6-c581785478aa"),
                Name = "User Guide 3.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/a9b16505-c50a-4d7b-99d6-c581785478aa.png",
                AddedAt = new DateTime(2024, 10, 19, 14, 26, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("68f8991f-4cdc-4938-aaa2-fde985f0de9b"),
                Name = "Operations Summary 20.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/68f8991f-4cdc-4938-aaa2-fde985f0de9b.txt",
                AddedAt = new DateTime(2024, 10, 7, 9, 23, 56, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("4057a05d-0938-40d4-ae58-e0e6238ad69d"),
                Name = "Receipt Record 13.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/4057a05d-0938-40d4-ae58-e0e6238ad69d.xlsx",
                AddedAt = new DateTime(2025, 3, 2, 7, 32, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("b2300c20-45fd-4b0f-87e0-d5dd1cbd799e"),
                Name = "Statistical Summary 1.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/b2300c20-45fd-4b0f-87e0-d5dd1cbd799e.docx",
                AddedAt = new DateTime(2025, 11, 19, 20, 4, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("c7ffea05-32ee-4400-a903-86118dcde893"),
                Name = "Agenda 13.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/c7ffea05-32ee-4400-a903-86118dcde893.xlsx",
                AddedAt = new DateTime(2025, 1, 24, 0, 9, 29, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("6d159251-a804-466f-9899-15ade9209901"),
                Name = "Documentation 5.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/6d159251-a804-466f-9899-15ade9209901.txt",
                AddedAt = new DateTime(2024, 1, 14, 15, 58, 6, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("e09f27fa-224e-46f8-8f7d-b1cd43398ee6"),
                Name = "Storyboard Frame 20.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/e09f27fa-224e-46f8-8f7d-b1cd43398ee6.xlsx",
                AddedAt = new DateTime(2024, 2, 19, 13, 5, 40, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("f00f0a0d-3f48-42eb-a213-cedca2a4a8b5"),
                Name = "Configuration 17.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/f00f0a0d-3f48-42eb-a213-cedca2a4a8b5.png",
                AddedAt = new DateTime(2025, 2, 7, 17, 53, 8, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("d6e95855-f2c6-4c20-81d5-46a556f66cb1"),
                Name = "Meeting Agenda 6.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/d6e95855-f2c6-4c20-81d5-46a556f66cb1.pptx",
                AddedAt = new DateTime(2025, 10, 27, 22, 47, 39, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("c482e273-bbc2-4bdd-8381-0cdb25f5062a"),
                Name = "Blueprint 15.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/c482e273-bbc2-4bdd-8381-0cdb25f5062a.pdf",
                AddedAt = new DateTime(2025, 9, 25, 7, 38, 5, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("efd36d02-1d97-4fbe-a857-7aa4bc2e2efb"),
                Name = "Tax Summary 5.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/efd36d02-1d97-4fbe-a857-7aa4bc2e2efb.pptx",
                AddedAt = new DateTime(2025, 6, 30, 1, 52, 37, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("7eda8c18-1ca4-40d6-a320-4e7316c4b0fd"),
                Name = "Financial Statement 9.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/7eda8c18-1ca4-40d6-a320-4e7316c4b0fd.pptx",
                AddedAt = new DateTime(2024, 6, 2, 9, 5, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("727b404c-e11a-4084-90f1-d09b1132d754"),
                Name = "Invoice 15.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/727b404c-e11a-4084-90f1-d09b1132d754.png",
                AddedAt = new DateTime(2024, 4, 19, 23, 49, 28, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("5797af1d-cc70-43f1-af68-4e84b4b40ce8"),
                Name = "Data Visualization 5.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/5797af1d-cc70-43f1-af68-4e84b4b40ce8.pdf",
                AddedAt = new DateTime(2024, 7, 19, 7, 40, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("3245277f-e208-4d6c-8716-d7347500dfa6"),
                Name = "Exam Solutions 5.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/3245277f-e208-4d6c-8716-d7347500dfa6.pdf",
                AddedAt = new DateTime(2024, 6, 11, 1, 23, 12, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("ed2e0d67-0ed8-4851-8fde-c918a495eec0"),
                Name = "Bank Statement 14.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/ed2e0d67-0ed8-4851-8fde-c918a495eec0.xlsx",
                AddedAt = new DateTime(2025, 9, 19, 22, 12, 39, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("54f4a8ef-54c2-4303-ac48-373d726523d6"),
                Name = "System Design 2.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/54f4a8ef-54c2-4303-ac48-373d726523d6.docx",
                AddedAt = new DateTime(2024, 6, 10, 6, 41, 14, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("08a2d00e-f098-4819-9b63-2601a2bfb797"),
                Name = "Student Summary 5.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/08a2d00e-f098-4819-9b63-2601a2bfb797.png",
                AddedAt = new DateTime(2024, 7, 23, 19, 47, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("96f3bf47-ef2e-4247-bd5f-f2168cfe1449"),
                Name = "Change Request 2.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/96f3bf47-ef2e-4247-bd5f-f2168cfe1449.xlsx",
                AddedAt = new DateTime(2024, 5, 9, 8, 55, 33, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("97cbfdd7-79a5-4da0-86ae-931aac5edf12"),
                Name = "Marketing Summary 18.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/97cbfdd7-79a5-4da0-86ae-931aac5edf12.docx",
                AddedAt = new DateTime(2025, 1, 27, 17, 45, 4, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("e5a65f43-d917-4574-b6a1-0178cfb02fc7"),
                Name = "Probability Sheet 1.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/e5a65f43-d917-4574-b6a1-0178cfb02fc7.png",
                AddedAt = new DateTime(2024, 7, 3, 2, 27, 36, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("638ea5a8-2b5f-4a98-b762-e1039d261212"),
                Name = "Financial Summary 7.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/638ea5a8-2b5f-4a98-b762-e1039d261212.xlsx",
                AddedAt = new DateTime(2024, 11, 6, 12, 12, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("dfedd8a8-6e3b-406f-b0d2-868429098ef8"),
                Name = "Business Report 19.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/dfedd8a8-6e3b-406f-b0d2-868429098ef8.pptx",
                AddedAt = new DateTime(2024, 11, 20, 11, 33, 49, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("e885e572-465a-40bb-907f-6b36d713cc8d"),
                Name = "Tax Document 2.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/e885e572-465a-40bb-907f-6b36d713cc8d.pdf",
                AddedAt = new DateTime(2025, 6, 6, 19, 28, 31, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("f47ddb7a-9e13-4cad-999b-022a902b98a5"),
                Name = "Business Report 19.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/f47ddb7a-9e13-4cad-999b-022a902b98a5.png",
                AddedAt = new DateTime(2025, 6, 22, 8, 0, 39, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("2d19abfd-6294-4374-80c1-113bb3df4082"),
                Name = "Draft File 17.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/2d19abfd-6294-4374-80c1-113bb3df4082.docx",
                AddedAt = new DateTime(2025, 10, 22, 13, 21, 42, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("c5f4e126-2c33-4112-8767-43b4ccdddbd2"),
                Name = "Diagnosis Report 3.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/c5f4e126-2c33-4112-8767-43b4ccdddbd2.txt",
                AddedAt = new DateTime(2025, 7, 11, 9, 3, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("49999268-5d22-48d1-bde0-2cde904c4821"),
                Name = "Artwork Reference 16.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/49999268-5d22-48d1-bde0-2cde904c4821.txt",
                AddedAt = new DateTime(2025, 10, 2, 7, 34, 10, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("f83ecdd8-0d18-4384-93ba-e8e8892e215d"),
                Name = "Digital Sketch 10.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/f83ecdd8-0d18-4384-93ba-e8e8892e215d.pdf",
                AddedAt = new DateTime(2025, 9, 23, 9, 29, 27, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("79400d29-f724-4ea3-b8b0-ac4630240bec"),
                Name = "Design Draft 4.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/79400d29-f724-4ea3-b8b0-ac4630240bec.pdf",
                AddedAt = new DateTime(2024, 1, 28, 2, 6, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("d1b97ed5-fb8e-43fd-9dd6-7a5410d5a48b"),
                Name = "Resource File 13.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/d1b97ed5-fb8e-43fd-9dd6-7a5410d5a48b.pptx",
                AddedAt = new DateTime(2024, 3, 15, 23, 23, 38, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("cf4d553c-e286-4267-9639-d5b02fad9c61"),
                Name = "Product Overview 18.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/cf4d553c-e286-4267-9639-d5b02fad9c61.xlsx",
                AddedAt = new DateTime(2024, 4, 21, 13, 10, 3, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("7bf77641-6182-459f-aa06-7e081f8c20e3"),
                Name = "Product Overview 16.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/7bf77641-6182-459f-aa06-7e081f8c20e3.pptx",
                AddedAt = new DateTime(2024, 11, 16, 14, 39, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("e77f6a08-bd8d-44a7-9595-857f90f01b84"),
                Name = "Expense Report 6.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/e77f6a08-bd8d-44a7-9595-857f90f01b84.xlsx",
                AddedAt = new DateTime(2024, 1, 11, 10, 34, 3, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("92f1e4c0-caca-48b6-91fc-edb3feb3e4bb"),
                Name = "Admin Instructions 9.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/92f1e4c0-caca-48b6-91fc-edb3feb3e4bb.xlsx",
                AddedAt = new DateTime(2025, 7, 24, 10, 3, 1, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("229fbf70-010a-4114-a41e-7e523e960e95"),
                Name = "Attachment 10.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/229fbf70-010a-4114-a41e-7e523e960e95.png",
                AddedAt = new DateTime(2024, 5, 3, 23, 32, 8, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("060deee0-d8c3-415d-8d87-77c7d98a62b6"),
                Name = "Wireframe 1.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/060deee0-d8c3-415d-8d87-77c7d98a62b6.xlsx",
                AddedAt = new DateTime(2024, 5, 9, 12, 2, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("600d584f-431c-4769-837d-8f2e228bb747"),
                Name = "Release Notes 14.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/600d584f-431c-4769-837d-8f2e228bb747.png",
                AddedAt = new DateTime(2024, 1, 14, 9, 5, 49, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("d3f264f9-e251-48c4-8bb8-ad6c4d4b9ea5"),
                Name = "Mockup 20.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/d3f264f9-e251-48c4-8bb8-ad6c4d4b9ea5.xlsx",
                AddedAt = new DateTime(2025, 1, 22, 4, 48, 9, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("628a0d1e-7ac0-4016-b614-568e0b12f2af"),
                Name = "Payment Record 15.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/628a0d1e-7ac0-4016-b614-568e0b12f2af.txt",
                AddedAt = new DateTime(2025, 4, 2, 11, 53, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("e8e90cfb-2873-4e1e-822d-57e54ec383a5"),
                Name = "Audit Document 10.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/e8e90cfb-2873-4e1e-822d-57e54ec383a5.pptx",
                AddedAt = new DateTime(2024, 9, 16, 21, 23, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("04c6f110-55aa-489e-9afa-738380165169"),
                Name = "Contract 5.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/04c6f110-55aa-489e-9afa-738380165169.txt",
                AddedAt = new DateTime(2025, 3, 17, 20, 9, 51, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("e8a57581-57d3-4923-afbf-ee2a7164801c"),
                Name = "Operational Guide 3.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/e8a57581-57d3-4923-afbf-ee2a7164801c.xlsx",
                AddedAt = new DateTime(2024, 3, 27, 0, 12, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("68483230-4fe6-4877-badf-f01001cd06eb"),
                Name = "Attendance Sheet 4.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/68483230-4fe6-4877-badf-f01001cd06eb.pdf",
                AddedAt = new DateTime(2024, 12, 31, 0, 52, 53, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4ecf5f24-e7d6-4ab3-ba61-2d797e08b1e2"),
                Name = "Medical Form 17.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/4ecf5f24-e7d6-4ab3-ba61-2d797e08b1e2.pdf",
                AddedAt = new DateTime(2024, 10, 2, 1, 2, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("f9ff7ebb-6a69-41af-96cb-9e4e29beb4af"),
                Name = "Correlation Results 7.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/f9ff7ebb-6a69-41af-96cb-9e4e29beb4af.pdf",
                AddedAt = new DateTime(2024, 8, 11, 16, 46, 10, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("0470fa1e-b365-49cb-9516-8949ca60be85"),
                Name = "Work Plan 7.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/0470fa1e-b365-49cb-9516-8949ca60be85.docx",
                AddedAt = new DateTime(2025, 5, 8, 2, 18, 9, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("357c6f37-12e8-4799-8e3d-46a8677ce8af"),
                Name = "Container Config 8.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/357c6f37-12e8-4799-8e3d-46a8677ce8af.pptx",
                AddedAt = new DateTime(2025, 4, 11, 18, 20, 59, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("cc4c7d3b-b1ae-426a-be8c-8de816030acd"),
                Name = "Graphic Draft 12.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/cc4c7d3b-b1ae-426a-be8c-8de816030acd.docx",
                AddedAt = new DateTime(2024, 6, 23, 2, 58, 59, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("2424fb63-5288-4071-b551-0a338c17d9db"),
                Name = "Assignment Sheet 13.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/2424fb63-5288-4071-b551-0a338c17d9db.txt",
                AddedAt = new DateTime(2025, 8, 24, 14, 34, 6, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("6902fadf-4a8f-45bb-8c93-c4e96421e5a0"),
                Name = "Crash Report 11.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/6902fadf-4a8f-45bb-8c93-c4e96421e5a0.txt",
                AddedAt = new DateTime(2025, 1, 22, 18, 18, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("6bc29e72-9699-490e-ad83-de2f72f592ec"),
                Name = "Partnership Contract 9.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/6bc29e72-9699-490e-ad83-de2f72f592ec.txt",
                AddedAt = new DateTime(2025, 1, 13, 6, 42, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("c65ca690-52b0-49de-8629-cc6c497e5806"),
                Name = "Cloud Policy 13.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/c65ca690-52b0-49de-8629-cc6c497e5806.txt",
                AddedAt = new DateTime(2024, 9, 7, 10, 37, 10, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("1f5a05cb-46ef-4b2b-b9b2-588633a77330"),
                Name = "Signed Form 2.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/1f5a05cb-46ef-4b2b-b9b2-588633a77330.pptx",
                AddedAt = new DateTime(2024, 6, 17, 14, 21, 48, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("71c4d5ea-6a02-41c9-9ca4-0f4adee5cda1"),
                Name = "Marketing Summary 14.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/71c4d5ea-6a02-41c9-9ca4-0f4adee5cda1.png",
                AddedAt = new DateTime(2025, 4, 5, 9, 50, 21, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("9bf07292-02b9-4d27-83cf-bacd1a4df175"),
                Name = "Dataset Export 20.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/9bf07292-02b9-4d27-83cf-bacd1a4df175.docx",
                AddedAt = new DateTime(2025, 6, 1, 14, 4, 18, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("b4d3ada4-d980-44e5-aa8d-eec88a20754b"),
                Name = "Requirements List 3.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/b4d3ada4-d980-44e5-aa8d-eec88a20754b.xlsx",
                AddedAt = new DateTime(2024, 2, 19, 12, 37, 12, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("c9e02bbb-f963-4891-b89d-69922410446f"),
                Name = "Lecture Notes 15.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/c9e02bbb-f963-4891-b89d-69922410446f.docx",
                AddedAt = new DateTime(2025, 9, 27, 12, 38, 29, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("e6f02c8c-ec6d-4347-827c-bdaac28caeb0"),
                Name = "Summary 1.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/e6f02c8c-ec6d-4347-827c-bdaac28caeb0.docx",
                AddedAt = new DateTime(2025, 1, 8, 16, 55, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("75ac7c65-a602-4c9a-b73f-8efdfb172d16"),
                Name = "Interview Feedback 11.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/75ac7c65-a602-4c9a-b73f-8efdfb172d16.txt",
                AddedAt = new DateTime(2025, 7, 23, 7, 3, 39, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("2027b871-f60a-4d89-86fe-29d4d0b026db"),
                Name = "Employee Handbook 12.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/2027b871-f60a-4d89-86fe-29d4d0b026db.txt",
                AddedAt = new DateTime(2024, 9, 22, 3, 42, 39, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("f25aa72c-9c50-4a75-ae29-5d7ec823e546"),
                Name = "Quick Guide 9.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/f25aa72c-9c50-4a75-ae29-5d7ec823e546.png",
                AddedAt = new DateTime(2024, 12, 11, 2, 17, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("ea47bdf0-fff5-4be1-a832-307b7ddd6acb"),
                Name = "Agenda 13.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/ea47bdf0-fff5-4be1-a832-307b7ddd6acb.pdf",
                AddedAt = new DateTime(2024, 5, 22, 17, 14, 33, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("30b2d6e7-77b1-42bf-9df4-f01f4e256d70"),
                Name = "Verification Letter 2.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/30b2d6e7-77b1-42bf-9df4-f01f4e256d70.png",
                AddedAt = new DateTime(2025, 7, 4, 16, 13, 54, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("edb3c2db-481f-4ddc-bd52-243c5b67d8fa"),
                Name = "Temporary Notes 12.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/edb3c2db-481f-4ddc-bd52-243c5b67d8fa.png",
                AddedAt = new DateTime(2024, 6, 22, 18, 53, 53, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("23e3736a-7eb9-495e-80ac-eaecf2e27a4d"),
                Name = "Payment Record 14.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/23e3736a-7eb9-495e-80ac-eaecf2e27a4d.xlsx",
                AddedAt = new DateTime(2025, 1, 23, 18, 3, 36, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("84788e82-62d6-4aaa-9477-249140609d11"),
                Name = "Business Proposal 17.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/84788e82-62d6-4aaa-9477-249140609d11.pdf",
                AddedAt = new DateTime(2025, 9, 17, 3, 1, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("ba58857e-d1a4-4738-af65-6c8d61fa92ee"),
                Name = "Audit Summary 10.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/ba58857e-d1a4-4738-af65-6c8d61fa92ee.png",
                AddedAt = new DateTime(2025, 6, 5, 15, 4, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("b3f82ce4-e70f-4f5c-bd81-7a25190010cb"),
                Name = "Tax Document 4.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/b3f82ce4-e70f-4f5c-bd81-7a25190010cb.pptx",
                AddedAt = new DateTime(2024, 12, 1, 7, 52, 57, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("0ea7a9ed-cc12-407f-b3b9-06403b725011"),
                Name = "Cluster Map 20.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/0ea7a9ed-cc12-407f-b3b9-06403b725011.png",
                AddedAt = new DateTime(2024, 3, 30, 15, 1, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("0347335e-7c9a-4320-8b27-925074d62d61"),
                Name = "Design Draft 15.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/0347335e-7c9a-4320-8b27-925074d62d61.pdf",
                AddedAt = new DateTime(2024, 5, 6, 5, 17, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("c68652ab-d0f2-4470-8a55-1826027f4f26"),
                Name = "Error Dump 1.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/c68652ab-d0f2-4470-8a55-1826027f4f26.png",
                AddedAt = new DateTime(2025, 8, 15, 19, 18, 16, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("3ead8784-22c2-4951-9793-7a92dab8a1f6"),
                Name = "Attendance Sheet 6.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/3ead8784-22c2-4951-9793-7a92dab8a1f6.txt",
                AddedAt = new DateTime(2025, 1, 4, 1, 35, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("2c2fc722-f8bb-45d2-9eb0-963b77e2544e"),
                Name = "HR Memo 8.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/2c2fc722-f8bb-45d2-9eb0-963b77e2544e.pptx",
                AddedAt = new DateTime(2025, 8, 23, 7, 14, 42, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("c5848d65-4342-4b8a-83a9-40e2d782288a"),
                Name = "Bank Statement 8.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/c5848d65-4342-4b8a-83a9-40e2d782288a.xlsx",
                AddedAt = new DateTime(2024, 9, 8, 22, 32, 29, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("aa0b1060-5efc-411a-9dcb-7d078a88a6bb"),
                Name = "Archived Document 16.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/aa0b1060-5efc-411a-9dcb-7d078a88a6bb.pptx",
                AddedAt = new DateTime(2025, 1, 26, 20, 30, 4, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("99f7a00e-a1ac-416a-ab62-d99f121db7ca"),
                Name = "Visual Draft 12.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/99f7a00e-a1ac-416a-ab62-d99f121db7ca.pdf",
                AddedAt = new DateTime(2024, 6, 14, 22, 52, 51, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("0dc6494d-6d95-445d-b15b-0699ce78f9f9"),
                Name = "Audit Summary 14.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/0dc6494d-6d95-445d-b15b-0699ce78f9f9.txt",
                AddedAt = new DateTime(2024, 7, 3, 1, 34, 8, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("a78397cf-ae52-4442-9cc4-1b655a7d11aa"),
                Name = "Temporary Notes 13.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/a78397cf-ae52-4442-9cc4-1b655a7d11aa.pdf",
                AddedAt = new DateTime(2025, 9, 7, 2, 21, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("5e52947e-af54-49ba-8d3e-9137f27c9765"),
                Name = "Hotfix Documentation 6.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/5e52947e-af54-49ba-8d3e-9137f27c9765.png",
                AddedAt = new DateTime(2025, 4, 25, 2, 20, 11, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("8fb39cb7-588f-4bee-bf3c-82f664c6677d"),
                Name = "Sales Overview 17.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/8fb39cb7-588f-4bee-bf3c-82f664c6677d.txt",
                AddedAt = new DateTime(2025, 1, 29, 10, 52, 38, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("e840b62f-594f-4bb1-9b1b-fa2ace24dde3"),
                Name = "Exercise Sheet 19.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/e840b62f-594f-4bb1-9b1b-fa2ace24dde3.pptx",
                AddedAt = new DateTime(2024, 2, 4, 3, 53, 33, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("edfb47e4-0b07-4535-ba96-7f62eb02ec8d"),
                Name = "Learning Guide 20.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/edfb47e4-0b07-4535-ba96-7f62eb02ec8d.txt",
                AddedAt = new DateTime(2025, 8, 11, 22, 40, 50, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("740dc3b7-7a86-4280-ba1d-69af6626aaaa"),
                Name = "Accounting Notes 3.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/740dc3b7-7a86-4280-ba1d-69af6626aaaa.png",
                AddedAt = new DateTime(2024, 8, 24, 1, 11, 32, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("524bef74-df26-4f54-95e9-6eda63f5ec08"),
                Name = "Data Export 11.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/524bef74-df26-4f54-95e9-6eda63f5ec08.png",
                AddedAt = new DateTime(2024, 9, 13, 2, 19, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a763a0a5-9e78-4162-849e-2b3f0d655aa4"),
                Name = "Company Policy 6.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/a763a0a5-9e78-4162-849e-2b3f0d655aa4.pptx",
                AddedAt = new DateTime(2024, 11, 5, 18, 1, 41, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("a830f453-ac0b-4158-b599-4a2bec66a09f"),
                Name = "Permission Letter 6.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/a830f453-ac0b-4158-b599-4a2bec66a09f.xlsx",
                AddedAt = new DateTime(2025, 1, 12, 11, 23, 56, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("d98425c8-0b46-466b-a8cd-39b33899e5c1"),
                Name = "Audit Document 4.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/d98425c8-0b46-466b-a8cd-39b33899e5c1.txt",
                AddedAt = new DateTime(2024, 8, 1, 3, 9, 48, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("0dff2420-6145-4a85-9eaa-ae9c6d35d9ad"),
                Name = "Syllabus 7.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/0dff2420-6145-4a85-9eaa-ae9c6d35d9ad.pptx",
                AddedAt = new DateTime(2025, 11, 7, 0, 38, 37, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("761e8f9a-2ad8-44b3-9b31-530e5bcd8b9a"),
                Name = "Partnership Contract 16.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/761e8f9a-2ad8-44b3-9b31-530e5bcd8b9a.xlsx",
                AddedAt = new DateTime(2025, 3, 18, 11, 56, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("94d95f4f-12f2-4f66-8898-4528d622a131"),
                Name = "Performance Graph 2.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/94d95f4f-12f2-4f66-8898-4528d622a131.pptx",
                AddedAt = new DateTime(2024, 8, 10, 0, 3, 42, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("11b45153-509f-4315-aa5f-99039bb93fab"),
                Name = "Confidentiality Agreement 6.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/11b45153-509f-4315-aa5f-99039bb93fab.pdf",
                AddedAt = new DateTime(2025, 5, 28, 7, 24, 15, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("24dac690-6e8b-492e-8e17-9d3e537fb31e"),
                Name = "General Notes 5.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/24dac690-6e8b-492e-8e17-9d3e537fb31e.txt",
                AddedAt = new DateTime(2024, 9, 12, 18, 59, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("ae351af9-cd99-4df6-b747-d43356f6c98f"),
                Name = "Authorization Form 16.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/ae351af9-cd99-4df6-b747-d43356f6c98f.pdf",
                AddedAt = new DateTime(2024, 11, 19, 12, 2, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("72ef33dd-f372-4c90-bac0-aad8d8e943f1"),
                Name = "Error Dump 8.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/72ef33dd-f372-4c90-bac0-aad8d8e943f1.png",
                AddedAt = new DateTime(2024, 2, 4, 18, 45, 23, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("493f385d-4007-425c-b044-3415ffaef2dc"),
                Name = "Testing Checklist 19.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/493f385d-4007-425c-b044-3415ffaef2dc.txt",
                AddedAt = new DateTime(2024, 7, 23, 13, 2, 40, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("1eb8005e-f99b-4a64-bce1-eb765c6a1a85"),
                Name = "Employment Agreement 13.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/1eb8005e-f99b-4a64-bce1-eb765c6a1a85.txt",
                AddedAt = new DateTime(2025, 10, 1, 5, 1, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("45459f48-29b6-4db9-86fa-4c5d5ad74959"),
                Name = "Server Map 3.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/45459f48-29b6-4db9-86fa-4c5d5ad74959.pptx",
                AddedAt = new DateTime(2024, 2, 18, 4, 13, 59, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("af7b709e-c04f-43bc-a73a-438c82180924"),
                Name = "Learning Summary 19.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/af7b709e-c04f-43bc-a73a-438c82180924.pptx",
                AddedAt = new DateTime(2024, 9, 28, 2, 7, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("7122a8dc-cbbf-4009-b205-c93a1f6beffa"),
                Name = "Storyboard Frame 7.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/7122a8dc-cbbf-4009-b205-c93a1f6beffa.pptx",
                AddedAt = new DateTime(2024, 7, 11, 8, 26, 18, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("725b54c9-aae3-4d26-b817-3c1945861172"),
                Name = "Summary 8.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/725b54c9-aae3-4d26-b817-3c1945861172.txt",
                AddedAt = new DateTime(2025, 1, 22, 2, 8, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("1857aa9c-e9c6-4574-94b0-9564457ec555"),
                Name = "Server Log 16.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/1857aa9c-e9c6-4574-94b0-9564457ec555.pptx",
                AddedAt = new DateTime(2024, 2, 23, 21, 15, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("a751c0b2-f59a-4d23-8040-ccb6877eff73"),
                Name = "Invoice Summary 3.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/a751c0b2-f59a-4d23-8040-ccb6877eff73.pdf",
                AddedAt = new DateTime(2024, 5, 17, 17, 35, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("06f8e2ec-37ff-447a-8e1b-0a6d0ef685e1"),
                Name = "Attendance Sheet 19.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/06f8e2ec-37ff-447a-8e1b-0a6d0ef685e1.txt",
                AddedAt = new DateTime(2024, 4, 2, 18, 45, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("41555b22-0101-43a6-ab8b-398f5beeaa03"),
                Name = "Practice File 5.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/41555b22-0101-43a6-ab8b-398f5beeaa03.txt",
                AddedAt = new DateTime(2025, 5, 21, 5, 36, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("93318896-c586-402b-a540-79760e0adb6f"),
                Name = "Legacy File 3.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/93318896-c586-402b-a540-79760e0adb6f.txt",
                AddedAt = new DateTime(2025, 10, 18, 6, 5, 52, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("5a3892b1-8d2b-48bf-81ad-085eeed7f4cc"),
                Name = "Training Manual 20.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/5a3892b1-8d2b-48bf-81ad-085eeed7f4cc.xlsx",
                AddedAt = new DateTime(2025, 11, 16, 1, 49, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("fa578ae1-c882-457f-8606-25a2599b81cf"),
                Name = "Work Session Summary 12.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/fa578ae1-c882-457f-8606-25a2599b81cf.png",
                AddedAt = new DateTime(2025, 4, 11, 20, 46, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("0a5b774d-611d-4f60-bdbd-2b8d2f44b080"),
                Name = "Dataset Export 15.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/0a5b774d-611d-4f60-bdbd-2b8d2f44b080.png",
                AddedAt = new DateTime(2025, 11, 9, 11, 53, 15, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("4a127efa-edcf-48bd-875a-fb238afbbd3f"),
                Name = "Report 17.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/4a127efa-edcf-48bd-875a-fb238afbbd3f.docx",
                AddedAt = new DateTime(2024, 6, 4, 7, 13, 13, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4a9baa48-49be-4a05-a270-0ddabc9ddfea"),
                Name = "Student Summary 8.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/4a9baa48-49be-4a05-a270-0ddabc9ddfea.txt",
                AddedAt = new DateTime(2024, 3, 13, 11, 25, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("6e8c6a6b-a053-446a-91d9-fa2919962da6"),
                Name = "Design Draft 5.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/6e8c6a6b-a053-446a-91d9-fa2919962da6.xlsx",
                AddedAt = new DateTime(2025, 9, 14, 21, 50, 9, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("d15649d3-dab2-4cb3-8b21-f43ce526be08"),
                Name = "Audit Summary 6.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/d15649d3-dab2-4cb3-8b21-f43ce526be08.pptx",
                AddedAt = new DateTime(2024, 4, 9, 15, 22, 27, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("eb91ff59-e5d6-4a83-8928-85d2f94bfc0f"),
                Name = "Client Notes 1.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/eb91ff59-e5d6-4a83-8928-85d2f94bfc0f.txt",
                AddedAt = new DateTime(2025, 11, 4, 2, 15, 14, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("14762566-eca5-4870-a740-1328557c7885"),
                Name = "Performance Graph 8.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/14762566-eca5-4870-a740-1328557c7885.pptx",
                AddedAt = new DateTime(2024, 1, 5, 7, 58, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("0529481a-0ade-469b-b986-c6e7b19be7e7"),
                Name = "Bank Statement 13.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/0529481a-0ade-469b-b986-c6e7b19be7e7.png",
                AddedAt = new DateTime(2024, 9, 11, 21, 25, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("f6916b97-d4ff-407e-b352-2caffe73df1b"),
                Name = "Report 19.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/f6916b97-d4ff-407e-b352-2caffe73df1b.xlsx",
                AddedAt = new DateTime(2024, 8, 26, 2, 17, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("109a9818-fbbc-45a5-bbf5-eb0d8917146d"),
                Name = "Service Mesh Plan 12.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/109a9818-fbbc-45a5-bbf5-eb0d8917146d.pdf",
                AddedAt = new DateTime(2024, 10, 31, 12, 3, 18, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("110c1e3e-35c3-4520-b78d-f6d7ec2b709b"),
                Name = "Instructions 19.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/110c1e3e-35c3-4520-b78d-f6d7ec2b709b.pdf",
                AddedAt = new DateTime(2025, 3, 10, 15, 23, 52, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("565eb799-cbbd-43d3-bb7a-7cd83cb29ec9"),
                Name = "Exercise Sheet 4.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/565eb799-cbbd-43d3-bb7a-7cd83cb29ec9.docx",
                AddedAt = new DateTime(2024, 1, 6, 5, 3, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("aa3887a6-fea8-4197-ab7c-d20004d7fce5"),
                Name = "Legacy File 14.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/aa3887a6-fea8-4197-ab7c-d20004d7fce5.pptx",
                AddedAt = new DateTime(2025, 6, 4, 22, 52, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("8ae9bba1-7234-44dc-9990-43e92623a8a6"),
                Name = "Invoice Summary 6.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/8ae9bba1-7234-44dc-9990-43e92623a8a6.png",
                AddedAt = new DateTime(2025, 3, 4, 0, 40, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("a8919856-a312-4664-a2e9-8119fb88e341"),
                Name = "Homework 10.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/a8919856-a312-4664-a2e9-8119fb88e341.png",
                AddedAt = new DateTime(2024, 8, 23, 21, 12, 28, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("31ec03c1-e879-47c4-8d6f-a8df029e51bc"),
                Name = "Performance Graph 14.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/31ec03c1-e879-47c4-8d6f-a8df029e51bc.pdf",
                AddedAt = new DateTime(2024, 2, 22, 21, 58, 9, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("47fbd7e1-c3ed-4d59-93c9-4aaa1e4813fb"),
                Name = "Work Plan 2.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/47fbd7e1-c3ed-4d59-93c9-4aaa1e4813fb.docx",
                AddedAt = new DateTime(2024, 5, 10, 23, 28, 54, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("9a10af65-3b5c-4198-8618-9a640f3fbed6"),
                Name = "UX Diagram 11.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/9a10af65-3b5c-4198-8618-9a640f3fbed6.xlsx",
                AddedAt = new DateTime(2024, 11, 5, 14, 47, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("49d1f450-280d-436e-9dee-36f6b8d0d816"),
                Name = "Raw Export 5.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/49d1f450-280d-436e-9dee-36f6b8d0d816.xlsx",
                AddedAt = new DateTime(2024, 5, 5, 8, 10, 20, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("4e33cc01-9107-4ef6-a238-d203bdf2bc6e"),
                Name = "Artwork Reference 19.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/4e33cc01-9107-4ef6-a238-d203bdf2bc6e.png",
                AddedAt = new DateTime(2024, 10, 4, 1, 18, 28, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("30c74646-3d53-43d1-95b1-d1c35dc52d3e"),
                Name = "Legacy File 20.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/30c74646-3d53-43d1-95b1-d1c35dc52d3e.pptx",
                AddedAt = new DateTime(2024, 2, 20, 14, 33, 53, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("72d4898c-30fd-4b9f-bc05-8d672275ef2a"),
                Name = "Blueprint 16.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/72d4898c-30fd-4b9f-bc05-8d672275ef2a.pptx",
                AddedAt = new DateTime(2024, 9, 22, 22, 58, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("dee85c51-24b8-4786-97d7-a844d4267769"),
                Name = "Class Notes 4.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/dee85c51-24b8-4786-97d7-a844d4267769.txt",
                AddedAt = new DateTime(2025, 4, 11, 14, 0, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("e4d61189-0b01-4465-98bb-85ef6d23dbd8"),
                Name = "Client Notes 17.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/e4d61189-0b01-4465-98bb-85ef6d23dbd8.xlsx",
                AddedAt = new DateTime(2024, 10, 27, 16, 2, 11, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("80d90177-0b0b-45f5-bfd5-d1253b36bf53"),
                Name = "Vaccination Record 8.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/80d90177-0b0b-45f5-bfd5-d1253b36bf53.png",
                AddedAt = new DateTime(2025, 10, 22, 9, 40, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("c33ca3a8-436b-464a-8478-f18ef90d7c88"),
                Name = "Admin Instructions 2.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/c33ca3a8-436b-464a-8478-f18ef90d7c88.docx",
                AddedAt = new DateTime(2024, 5, 5, 21, 10, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("2e2c759b-2bb5-4393-baf5-1f02f964262a"),
                Name = "Authorization Form 7.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/2e2c759b-2bb5-4393-baf5-1f02f964262a.xlsx",
                AddedAt = new DateTime(2024, 9, 14, 17, 21, 36, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("391c17ab-dd63-43dd-bd10-42280c0ab796"),
                Name = "Performance Report 5.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/391c17ab-dd63-43dd-bd10-42280c0ab796.pdf",
                AddedAt = new DateTime(2025, 2, 15, 13, 22, 37, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("1bac7d2e-8ad9-40a3-b64e-288398831097"),
                Name = "Dataset Export 4.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/1bac7d2e-8ad9-40a3-b64e-288398831097.docx",
                AddedAt = new DateTime(2024, 2, 14, 23, 39, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4f076a46-ab8a-4022-80bb-12d7243caab3"),
                Name = "Revenue Sheet 1.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/4f076a46-ab8a-4022-80bb-12d7243caab3.docx",
                AddedAt = new DateTime(2024, 7, 9, 18, 25, 15, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("41ed3209-43b1-4b4e-bb6d-93e4aeec16a9"),
                Name = "Hotfix Documentation 2.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/41ed3209-43b1-4b4e-bb6d-93e4aeec16a9.pptx",
                AddedAt = new DateTime(2025, 7, 10, 13, 29, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("16fb3af3-610f-47a5-b09f-9eddf20fc423"),
                Name = "Training Notes 11.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/16fb3af3-610f-47a5-b09f-9eddf20fc423.txt",
                AddedAt = new DateTime(2024, 7, 22, 6, 27, 1, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("0d012bd7-072e-4c72-9019-8f52b9638453"),
                Name = "Admin Instructions 9.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/0d012bd7-072e-4c72-9019-8f52b9638453.pdf",
                AddedAt = new DateTime(2025, 1, 23, 0, 7, 1, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("fcdf48c1-0c10-4fe0-b124-9d002cf877ef"),
                Name = "Permission Letter 12.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/fcdf48c1-0c10-4fe0-b124-9d002cf877ef.png",
                AddedAt = new DateTime(2024, 6, 1, 23, 57, 16, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("506736bf-1e54-43bf-b889-803770af3634"),
                Name = "Internal Testing Document 3.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/506736bf-1e54-43bf-b889-803770af3634.txt",
                AddedAt = new DateTime(2025, 1, 31, 6, 12, 13, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("36851905-2710-4f01-b910-e4a1ffb65298"),
                Name = "Class Notes 18.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/36851905-2710-4f01-b910-e4a1ffb65298.xlsx",
                AddedAt = new DateTime(2024, 1, 12, 1, 35, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("66e238fc-79d0-4900-a67a-8d534439a75a"),
                Name = "Department Summary 5.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/66e238fc-79d0-4900-a67a-8d534439a75a.pptx",
                AddedAt = new DateTime(2024, 8, 2, 10, 48, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("0cf5a17d-8b34-4721-8ca3-e361df33d6c1"),
                Name = "Training Manual 17.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/0cf5a17d-8b34-4721-8ca3-e361df33d6c1.txt",
                AddedAt = new DateTime(2024, 10, 7, 23, 32, 10, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("1e93f58d-d695-4d5b-b738-13f4727cfa9e"),
                Name = "Operational Checklist 14.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/1e93f58d-d695-4d5b-b738-13f4727cfa9e.docx",
                AddedAt = new DateTime(2025, 10, 26, 16, 27, 40, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("6f1f1cde-8f42-4933-af08-871cced4c2a3"),
                Name = "Logo Design 2.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/6f1f1cde-8f42-4933-af08-871cced4c2a3.docx",
                AddedAt = new DateTime(2024, 5, 5, 23, 8, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("5955ab75-c9a2-4d2e-89f3-cdf0c9c4df36"),
                Name = "Network Topology 10.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/5955ab75-c9a2-4d2e-89f3-cdf0c9c4df36.xlsx",
                AddedAt = new DateTime(2025, 1, 14, 23, 27, 56, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("6dbf32d4-00a9-4505-8204-17845bcddc6f"),
                Name = "Practice File 3.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/6dbf32d4-00a9-4505-8204-17845bcddc6f.xlsx",
                AddedAt = new DateTime(2025, 5, 14, 10, 58, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("2ad1247f-c66f-4f8c-ae0a-b9b0f11335fb"),
                Name = "Visual Draft 12.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/2ad1247f-c66f-4f8c-ae0a-b9b0f11335fb.docx",
                AddedAt = new DateTime(2024, 10, 31, 8, 15, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("fbb35abf-3399-41a4-8645-5529b5a0afb6"),
                Name = "Manual Snapshot 8.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/fbb35abf-3399-41a4-8645-5529b5a0afb6.pdf",
                AddedAt = new DateTime(2024, 8, 9, 10, 42, 47, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("fd21a566-833e-4d7b-b42f-01f4f4a24ffa"),
                Name = "Notes 20.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/fd21a566-833e-4d7b-b42f-01f4f4a24ffa.xlsx",
                AddedAt = new DateTime(2024, 9, 25, 9, 57, 12, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("868904c4-c480-454e-8537-d6bf0f22b7c6"),
                Name = "Hiring Form 11.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/868904c4-c480-454e-8537-d6bf0f22b7c6.docx",
                AddedAt = new DateTime(2025, 2, 10, 12, 48, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("70cc378c-52a5-4be8-bb45-942e4721fb87"),
                Name = "Configuration 11.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/70cc378c-52a5-4be8-bb45-942e4721fb87.xlsx",
                AddedAt = new DateTime(2025, 9, 12, 12, 47, 27, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("1993214c-2e77-48c5-a0ba-a008916087f0"),
                Name = "System Log 14.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/1993214c-2e77-48c5-a0ba-a008916087f0.pptx",
                AddedAt = new DateTime(2024, 8, 21, 19, 53, 29, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("afd1f9fb-aebd-4c45-a414-97df8a3d8223"),
                Name = "Marketing Summary 17.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/afd1f9fb-aebd-4c45-a414-97df8a3d8223.png",
                AddedAt = new DateTime(2024, 11, 28, 13, 23, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("b18f76c8-214a-45c2-9080-ffc03d0312ea"),
                Name = "Performance Graph 13.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/b18f76c8-214a-45c2-9080-ffc03d0312ea.pptx",
                AddedAt = new DateTime(2024, 9, 11, 9, 2, 20, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("b9c3f4ca-3b5a-4a7a-82ee-69d1214728af"),
                Name = "Contract 12.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/b9c3f4ca-3b5a-4a7a-82ee-69d1214728af.pdf",
                AddedAt = new DateTime(2025, 9, 9, 3, 56, 1, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("b4ece921-f15f-4f32-827a-85c4a898af7b"),
                Name = "Medical Record 9.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/b4ece921-f15f-4f32-827a-85c4a898af7b.pptx",
                AddedAt = new DateTime(2024, 4, 13, 12, 54, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a13acbde-ad9c-4f94-bb27-772b6284f0f2"),
                Name = "Infrastructure Diagram 12.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/a13acbde-ad9c-4f94-bb27-772b6284f0f2.xlsx",
                AddedAt = new DateTime(2024, 9, 6, 1, 34, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("a5eedee1-703a-4917-8046-e00aeae99efd"),
                Name = "Process Mapping 9.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/a5eedee1-703a-4917-8046-e00aeae99efd.pptx",
                AddedAt = new DateTime(2025, 8, 13, 7, 17, 41, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("830769a2-b9cc-478a-abb1-d266cf63f8b1"),
                Name = "Feature Description 11.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/830769a2-b9cc-478a-abb1-d266cf63f8b1.pdf",
                AddedAt = new DateTime(2025, 8, 24, 1, 45, 12, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("1281f10c-fdff-4222-85b2-a3ac6474c876"),
                Name = "Project Notes 4.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/1281f10c-fdff-4222-85b2-a3ac6474c876.docx",
                AddedAt = new DateTime(2024, 12, 19, 17, 58, 52, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("6ff3899e-6fea-45fe-9879-262fa2137e60"),
                Name = "Meeting Agenda 13.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/6ff3899e-6fea-45fe-9879-262fa2137e60.xlsx",
                AddedAt = new DateTime(2025, 5, 1, 2, 18, 10, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a029be01-642e-4c80-bb26-07602802a4b3"),
                Name = "Training Notes 7.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/a029be01-642e-4c80-bb26-07602802a4b3.png",
                AddedAt = new DateTime(2025, 11, 5, 13, 7, 15, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("616c92de-56e6-49f7-8d51-f0cfc3afd567"),
                Name = "Practice File 11.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/616c92de-56e6-49f7-8d51-f0cfc3afd567.txt",
                AddedAt = new DateTime(2025, 3, 20, 19, 51, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("343dc503-d358-40e7-b18d-8713dc6b1fbb"),
                Name = "Process Mapping 2.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/343dc503-d358-40e7-b18d-8713dc6b1fbb.xlsx",
                AddedAt = new DateTime(2024, 12, 10, 6, 18, 4, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("8a1ce3f4-f04c-4a21-a645-4b83434d39a4"),
                Name = "Operational Guide 1.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/8a1ce3f4-f04c-4a21-a645-4b83434d39a4.pptx",
                AddedAt = new DateTime(2024, 5, 19, 16, 5, 20, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("b3313cd8-7b2b-4d7b-a2ac-8c47ecf95834"),
                Name = "Employee Handbook 3.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/b3313cd8-7b2b-4d7b-a2ac-8c47ecf95834.txt",
                AddedAt = new DateTime(2025, 3, 21, 20, 11, 31, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("327fbb37-3a07-4b25-ade7-b2d4f2ed1bba"),
                Name = "Tax Document 6.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/327fbb37-3a07-4b25-ade7-b2d4f2ed1bba.xlsx",
                AddedAt = new DateTime(2025, 4, 8, 9, 54, 28, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("6ab6f54f-540b-4781-bf7d-335503538852"),
                Name = "Raw Export 1.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/6ab6f54f-540b-4781-bf7d-335503538852.docx",
                AddedAt = new DateTime(2025, 10, 12, 13, 33, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("74a60fa1-6186-4e04-a164-838081d0c7e8"),
                Name = "Training Handbook 20.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/74a60fa1-6186-4e04-a164-838081d0c7e8.png",
                AddedAt = new DateTime(2025, 9, 6, 4, 55, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("0d8f1c5f-25cb-4da3-a856-e53ef6578aff"),
                Name = "Employee Handbook 9.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/0d8f1c5f-25cb-4da3-a856-e53ef6578aff.txt",
                AddedAt = new DateTime(2025, 2, 10, 21, 54, 23, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("eb561f6c-e5c4-415d-a94e-23a407c9bf5a"),
                Name = "Training Slides 11.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/eb561f6c-e5c4-415d-a94e-23a407c9bf5a.pdf",
                AddedAt = new DateTime(2025, 6, 22, 0, 5, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("7368bb0f-aa3b-4571-8e9d-c332a484996b"),
                Name = "Prescription Sheet 17.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/7368bb0f-aa3b-4571-8e9d-c332a484996b.docx",
                AddedAt = new DateTime(2025, 10, 5, 5, 2, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("067f61fa-dccb-4b9a-a195-07757e788a35"),
                Name = "Service Mesh Plan 13.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/067f61fa-dccb-4b9a-a195-07757e788a35.png",
                AddedAt = new DateTime(2024, 8, 11, 22, 4, 41, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("b84f6d62-38f8-4834-9185-63623e1f17b6"),
                Name = "Lecture Notes 11.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/b84f6d62-38f8-4834-9185-63623e1f17b6.docx",
                AddedAt = new DateTime(2024, 1, 4, 22, 54, 59, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("13493563-bfe2-42c2-9c7f-cc50256c6786"),
                Name = "Training Handbook 9.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/13493563-bfe2-42c2-9c7f-cc50256c6786.xlsx",
                AddedAt = new DateTime(2025, 4, 15, 9, 38, 48, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("3d942a6f-0766-486e-a245-8d9afd3c678f"),
                Name = "Diagram 12.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/3d942a6f-0766-486e-a245-8d9afd3c678f.xlsx",
                AddedAt = new DateTime(2025, 11, 16, 13, 35, 7, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("ceb337a0-55b3-4ceb-8870-8d5796a09aa2"),
                Name = "Machine Learning Output 17.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/ceb337a0-55b3-4ceb-8870-8d5796a09aa2.txt",
                AddedAt = new DateTime(2025, 11, 28, 22, 39, 6, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("7cff958f-e3a0-4707-86a6-99c168f251b5"),
                Name = "Client Approval 1.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/7cff958f-e3a0-4707-86a6-99c168f251b5.pptx",
                AddedAt = new DateTime(2024, 11, 26, 23, 4, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("8af17c57-ed89-412a-bb9e-c876289f1e7b"),
                Name = "Internal Communication 16.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/8af17c57-ed89-412a-bb9e-c876289f1e7b.txt",
                AddedAt = new DateTime(2025, 2, 9, 12, 12, 8, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("cce23af1-d4cc-40ad-a309-6c224abd6fff"),
                Name = "Form Submission 6.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/cce23af1-d4cc-40ad-a309-6c224abd6fff.xlsx",
                AddedAt = new DateTime(2025, 5, 16, 2, 56, 0, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("be7ed2ed-394f-4427-ad73-8f72bb13f0a2"),
                Name = "Storyboard Frame 19.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/be7ed2ed-394f-4427-ad73-8f72bb13f0a2.png",
                AddedAt = new DateTime(2025, 8, 15, 12, 43, 5, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("7272c79c-3e81-45c4-b486-760d80161fcb"),
                Name = "Presentation 11.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/7272c79c-3e81-45c4-b486-760d80161fcb.txt",
                AddedAt = new DateTime(2025, 8, 3, 23, 9, 12, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("36a3fcd5-fda9-491a-8d5e-b00275c10abf"),
                Name = "Receipt Record 12.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/36a3fcd5-fda9-491a-8d5e-b00275c10abf.png",
                AddedAt = new DateTime(2025, 9, 18, 0, 43, 36, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("3add439b-95bf-496b-8fa0-cab34d45d2e9"),
                Name = "Transaction Report 8.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/3add439b-95bf-496b-8fa0-cab34d45d2e9.png",
                AddedAt = new DateTime(2025, 10, 26, 18, 4, 50, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4473ad0f-5cf8-4b11-83f4-c4179a99fd84"),
                Name = "Study Material 2.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/4473ad0f-5cf8-4b11-83f4-c4179a99fd84.txt",
                AddedAt = new DateTime(2024, 2, 12, 1, 59, 20, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("e8482fb8-6886-42ac-9ccf-993a15327f9b"),
                Name = "Process Description 11.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/e8482fb8-6886-42ac-9ccf-993a15327f9b.png",
                AddedAt = new DateTime(2024, 9, 8, 4, 33, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("5b84ceba-3936-4c1e-9c61-0c95bb6ab2ad"),
                Name = "Procurement Request 20.pdf",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/5b84ceba-3936-4c1e-9c61-0c95bb6ab2ad.pdf",
                AddedAt = new DateTime(2025, 9, 14, 0, 48, 1, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("2268583f-9730-4140-831e-490bfc8cca62"),
                Name = "Course Notes 18.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/2268583f-9730-4140-831e-490bfc8cca62.xlsx",
                AddedAt = new DateTime(2024, 2, 16, 6, 16, 24, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("dfbfc2a3-345f-406a-b24c-09b5cdca57bb"),
                Name = "Class Notes 8.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/dfbfc2a3-345f-406a-b24c-09b5cdca57bb.pptx",
                AddedAt = new DateTime(2025, 8, 26, 14, 30, 58, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("83249eaf-2150-4f82-abca-cca60644bb22"),
                Name = "Archived Document 6.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/83249eaf-2150-4f82-abca-cca60644bb22.xlsx",
                AddedAt = new DateTime(2025, 3, 30, 7, 1, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("9efea894-ffa2-4d5c-b8e7-f555982d489a"),
                Name = "Certification 19.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/9efea894-ffa2-4d5c-b8e7-f555982d489a.png",
                AddedAt = new DateTime(2024, 9, 13, 0, 39, 45, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("8852eafa-6067-43de-899d-693358679187"),
                Name = "HR Contract 1.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/8852eafa-6067-43de-899d-693358679187.pdf",
                AddedAt = new DateTime(2024, 7, 4, 0, 59, 49, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("ac91eb22-2228-4117-a84e-398d6e21c18e"),
                Name = "Service Mesh Plan 10.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/ac91eb22-2228-4117-a84e-398d6e21c18e.txt",
                AddedAt = new DateTime(2024, 6, 29, 16, 53, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("1c4237a0-6a5f-4820-a25e-b8a287b7e816"),
                Name = "Container Config 12.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/1c4237a0-6a5f-4820-a25e-b8a287b7e816.xlsx",
                AddedAt = new DateTime(2024, 6, 24, 18, 24, 50, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("6652728a-f322-43fe-869d-61c59aaf2cbf"),
                Name = "Artwork Reference 3.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/6652728a-f322-43fe-869d-61c59aaf2cbf.docx",
                AddedAt = new DateTime(2025, 10, 2, 17, 55, 25, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("b0b03297-21da-4301-bb97-c8531ef8f3b1"),
                Name = "Exam Preparation 19.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/b0b03297-21da-4301-bb97-c8531ef8f3b1.pptx",
                AddedAt = new DateTime(2025, 9, 5, 4, 26, 14, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("23ca6cf8-986a-425b-bbd4-8e47f9740341"),
                Name = "Operational Guide 6.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/23ca6cf8-986a-425b-bbd4-8e47f9740341.pdf",
                AddedAt = new DateTime(2025, 6, 4, 22, 37, 44, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("5fc6693c-6352-4a89-b674-6c2c520fd8dc"),
                Name = "Reference Sheet 7.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/5fc6693c-6352-4a89-b674-6c2c520fd8dc.pptx",
                AddedAt = new DateTime(2024, 3, 5, 6, 56, 47, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("509b1073-9342-4af1-bdbe-eff798296e77"),
                Name = "Analytics Report 6.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/509b1073-9342-4af1-bdbe-eff798296e77.pdf",
                AddedAt = new DateTime(2025, 8, 17, 5, 16, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("cf5129ad-f33a-44ff-9658-45e0b54aae8d"),
                Name = "Migration Data 10.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/cf5129ad-f33a-44ff-9658-45e0b54aae8d.txt",
                AddedAt = new DateTime(2025, 1, 29, 19, 39, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("3442e566-e83e-4d14-9df6-1c954c828b7a"),
                Name = "IAM Roles Document 1.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/3442e566-e83e-4d14-9df6-1c954c828b7a.xlsx",
                AddedAt = new DateTime(2024, 9, 10, 7, 28, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("b9d6120d-0266-45c3-8a76-dc0fc1a740d6"),
                Name = "Test Report 9.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/b9d6120d-0266-45c3-8a76-dc0fc1a740d6.pptx",
                AddedAt = new DateTime(2024, 10, 3, 23, 6, 13, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("dd3e89ce-9013-463d-9925-2f4a106bd53d"),
                Name = "Operational Guide 13.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/dd3e89ce-9013-463d-9925-2f4a106bd53d.pptx",
                AddedAt = new DateTime(2024, 3, 12, 13, 40, 16, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("8deefb73-5211-403d-a374-18e5dade2341"),
                Name = "Internal Memo 4.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/8deefb73-5211-403d-a374-18e5dade2341.txt",
                AddedAt = new DateTime(2025, 8, 14, 2, 18, 38, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("34f94c2f-fd23-45b1-8c88-f8b8a8dd21fc"),
                Name = "Certification 4.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/34f94c2f-fd23-45b1-8c88-f8b8a8dd21fc.png",
                AddedAt = new DateTime(2024, 11, 25, 13, 46, 48, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("9b45a713-c241-44bb-bdef-0d2c0c7ce063"),
                Name = "Assignment Sheet 8.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/9b45a713-c241-44bb-bdef-0d2c0c7ce063.png",
                AddedAt = new DateTime(2025, 3, 15, 1, 27, 8, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("ca184750-f40a-4d14-ba06-e6eda721a30b"),
                Name = "Infrastructure Diagram 18.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/ca184750-f40a-4d14-ba06-e6eda721a30b.pdf",
                AddedAt = new DateTime(2025, 11, 16, 0, 59, 48, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("c19636fe-cef7-4de0-ab3b-9d7fee4ef79b"),
                Name = "Payroll Report 11.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/c19636fe-cef7-4de0-ab3b-9d7fee4ef79b.pptx",
                AddedAt = new DateTime(2025, 7, 18, 8, 9, 47, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("06c9743e-19f4-492e-98fb-17508611b246"),
                Name = "Revision Notes 4.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/06c9743e-19f4-492e-98fb-17508611b246.png",
                AddedAt = new DateTime(2024, 5, 7, 22, 26, 42, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("9edc1592-f62b-46d1-8dd6-01f70e11a863"),
                Name = "Training Slides 5.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/9edc1592-f62b-46d1-8dd6-01f70e11a863.docx",
                AddedAt = new DateTime(2025, 8, 8, 3, 23, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("e132dd10-48af-4d5d-8107-d571286f3851"),
                Name = "Client Approval 19.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/e132dd10-48af-4d5d-8107-d571286f3851.pptx",
                AddedAt = new DateTime(2025, 7, 8, 17, 43, 14, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a7fcaf67-c839-42f3-b0b4-e7f691c63a26"),
                Name = "Student Summary 5.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/a7fcaf67-c839-42f3-b0b4-e7f691c63a26.pptx",
                AddedAt = new DateTime(2024, 12, 17, 17, 53, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("b8f85bb4-1be7-437c-80a5-4963a13f81a3"),
                Name = "Project Notes 18.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/b8f85bb4-1be7-437c-80a5-4963a13f81a3.pdf",
                AddedAt = new DateTime(2025, 1, 7, 15, 9, 21, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("e90c029c-e120-486e-bbf2-1d3ab3b83874"),
                Name = "Flowchart 12.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/e90c029c-e120-486e-bbf2-1d3ab3b83874.pptx",
                AddedAt = new DateTime(2024, 10, 3, 18, 33, 8, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("4df48f8c-4731-4c97-8535-436a0a063b69"),
                Name = "Project Asset 8.png",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/4df48f8c-4731-4c97-8535-436a0a063b69.png",
                AddedAt = new DateTime(2024, 8, 29, 22, 24, 21, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("916e7301-bedc-4ae2-83c1-53d76b87eb04"),
                Name = "UX Diagram 20.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/916e7301-bedc-4ae2-83c1-53d76b87eb04.txt",
                AddedAt = new DateTime(2024, 3, 25, 22, 19, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("0b1d682b-4318-45e1-9c34-6cdb743ecb0a"),
                Name = "Artwork Reference 9.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/0b1d682b-4318-45e1-9c34-6cdb743ecb0a.txt",
                AddedAt = new DateTime(2024, 6, 1, 2, 59, 20, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a5f6f521-3389-4fc4-a67b-ed833bd5fe2d"),
                Name = "Process Mapping 20.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/a5f6f521-3389-4fc4-a67b-ed833bd5fe2d.pdf",
                AddedAt = new DateTime(2024, 11, 1, 11, 20, 21, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("026a55db-e502-4db9-aacb-3cab00a41d66"),
                Name = "Lecture Summary 1.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/026a55db-e502-4db9-aacb-3cab00a41d66.png",
                AddedAt = new DateTime(2024, 2, 29, 12, 37, 40, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("dbdacd45-525f-4d12-a880-4c96f635b251"),
                Name = "Bank Statement 6.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/dbdacd45-525f-4d12-a880-4c96f635b251.pdf",
                AddedAt = new DateTime(2024, 6, 10, 3, 8, 18, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("892bd76e-c178-4f11-ba21-f6191b8da7e9"),
                Name = "Legacy File 16.xlsx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/892bd76e-c178-4f11-ba21-f6191b8da7e9.xlsx",
                AddedAt = new DateTime(2025, 6, 30, 17, 41, 33, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("66e0c73e-3843-48b7-be0b-12618da0255e"),
                Name = "Blueprint 18.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/66e0c73e-3843-48b7-be0b-12618da0255e.docx",
                AddedAt = new DateTime(2024, 7, 22, 22, 6, 34, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("27e6344d-3edf-4f93-904f-3b1314bd5ea5"),
                Name = "Logo Design 1.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/27e6344d-3edf-4f93-904f-3b1314bd5ea5.pdf",
                AddedAt = new DateTime(2024, 1, 13, 4, 10, 37, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("13d308dd-3a86-49a7-830a-2314d8a22a8c"),
                Name = "Lecture Summary 2.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/13d308dd-3a86-49a7-830a-2314d8a22a8c.png",
                AddedAt = new DateTime(2025, 10, 26, 15, 33, 1, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("36253f18-096f-42d0-8aae-60cb3c88cd97"),
                Name = "Manual Snapshot 16.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/36253f18-096f-42d0-8aae-60cb3c88cd97.pptx",
                AddedAt = new DateTime(2024, 4, 1, 6, 44, 50, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("c4048268-ef74-4d34-a28a-59949e5c6d6f"),
                Name = "Backend Notes 8.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/c4048268-ef74-4d34-a28a-59949e5c6d6f.png",
                AddedAt = new DateTime(2025, 7, 14, 17, 11, 13, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("64c2e6df-136b-441a-8eb0-f3c17d1be806"),
                Name = "Pipeline Script 4.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/64c2e6df-136b-441a-8eb0-f3c17d1be806.pdf",
                AddedAt = new DateTime(2025, 1, 9, 9, 20, 57, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("bb6f0516-516b-4290-9b90-2c0b1843df11"),
                Name = "Annual Summary 1.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/bb6f0516-516b-4290-9b90-2c0b1843df11.png",
                AddedAt = new DateTime(2024, 8, 26, 11, 21, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("43ad10f7-13d7-43bb-a009-2b1e4c851868"),
                Name = "Procurement Request 18.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/43ad10f7-13d7-43bb-a009-2b1e4c851868.xlsx",
                AddedAt = new DateTime(2024, 7, 17, 15, 42, 26, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("a81df2f9-9290-4af0-a426-ad06d0589af3"),
                Name = "Photo Reference 8.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/a81df2f9-9290-4af0-a426-ad06d0589af3.xlsx",
                AddedAt = new DateTime(2024, 2, 21, 4, 49, 18, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("1ea32fd4-c25f-4aaf-9120-1b089157c28a"),
                Name = "Quarterly Review 4.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/1ea32fd4-c25f-4aaf-9120-1b089157c28a.txt",
                AddedAt = new DateTime(2024, 3, 11, 8, 23, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("2c706c0c-53d2-423a-b571-6de36c6551ed"),
                Name = "Quick Guide 11.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/2c706c0c-53d2-423a-b571-6de36c6551ed.xlsx",
                AddedAt = new DateTime(2024, 6, 20, 0, 5, 7, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("70f1a5f0-2ab3-4990-929a-d53ee0ecc6a9"),
                Name = "Tax Document 7.xlsx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/70f1a5f0-2ab3-4990-929a-d53ee0ecc6a9.xlsx",
                AddedAt = new DateTime(2025, 9, 11, 1, 21, 22, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("e842fa3a-c572-48c0-9dda-3810b45ff133"),
                Name = "Meeting Agenda 1.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/e842fa3a-c572-48c0-9dda-3810b45ff133.pptx",
                AddedAt = new DateTime(2024, 8, 25, 3, 1, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("5295b3fd-1a0c-4b83-a0a1-bb04dccf40df"),
                Name = "Learning Summary 5.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/5295b3fd-1a0c-4b83-a0a1-bb04dccf40df.docx",
                AddedAt = new DateTime(2025, 3, 12, 7, 0, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("84c3aede-faea-4546-a93e-8c8d95d8b289"),
                Name = "Employment Agreement 15.png",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/84c3aede-faea-4546-a93e-8c8d95d8b289.png",
                AddedAt = new DateTime(2025, 10, 9, 17, 37, 4, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("9354fd6e-680f-47a1-a4db-a900ec33f7fb"),
                Name = "Insurance Document 5.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/9354fd6e-680f-47a1-a4db-a900ec33f7fb.txt",
                AddedAt = new DateTime(2025, 10, 22, 1, 37, 54, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("04c762ff-386e-45b5-acef-672582a5fe03"),
                Name = "Performance Graph 12.pptx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/04c762ff-386e-45b5-acef-672582a5fe03.pptx",
                AddedAt = new DateTime(2025, 10, 8, 23, 53, 36, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("9e5bd71e-4631-4a69-9a92-4e66c372fcf7"),
                Name = "Illustration Sketch 7.docx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/9e5bd71e-4631-4a69-9a92-4e66c372fcf7.docx",
                AddedAt = new DateTime(2025, 10, 30, 23, 0, 2, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("f4ed5454-3d22-476c-b8ec-7316e1d228f4"),
                Name = "Hiring Form 11.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/f4ed5454-3d22-476c-b8ec-7316e1d228f4.pptx",
                AddedAt = new DateTime(2024, 12, 2, 7, 43, 17, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("4499d56c-1bcf-4a00-967f-f2c1499e3bb8"),
                Name = "Training Notes 5.xlsx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/4499d56c-1bcf-4a00-967f-f2c1499e3bb8.xlsx",
                AddedAt = new DateTime(2024, 1, 5, 17, 8, 17, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("d0e0f4c1-82a6-443e-be89-3fb1b6f71322"),
                Name = "Employee Record 6.pptx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/d0e0f4c1-82a6-443e-be89-3fb1b6f71322.pptx",
                AddedAt = new DateTime(2024, 2, 20, 23, 41, 19, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("2aab82f6-bc60-483f-93cd-18c3c4670d28"),
                Name = "Payroll Summary 5.pdf",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/2aab82f6-bc60-483f-93cd-18c3c4670d28.pdf",
                AddedAt = new DateTime(2024, 2, 25, 10, 53, 43, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a16a463b-1f50-48fb-ba00-a8d9ce382d37"),
                Name = "Operational Checklist 20.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/a16a463b-1f50-48fb-ba00-a8d9ce382d37.txt",
                AddedAt = new DateTime(2024, 11, 5, 4, 32, 50, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("a61749d9-1dc8-4a86-a2f1-6721f0dbe5b3"),
                Name = "Recruitment Summary 3.txt",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/a61749d9-1dc8-4a86-a2f1-6721f0dbe5b3.txt",
                AddedAt = new DateTime(2024, 7, 29, 1, 58, 46, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("ae7d09d3-df0f-44bf-85a7-6d4a55338c49"),
                Name = "Homework 2.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/ae7d09d3-df0f-44bf-85a7-6d4a55338c49.docx",
                AddedAt = new DateTime(2025, 4, 30, 12, 17, 30, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("05950e48-ccd0-4c5d-acff-d1370b5c78dc"),
                Name = "Service Mesh Plan 14.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/05950e48-ccd0-4c5d-acff-d1370b5c78dc.txt",
                AddedAt = new DateTime(2024, 7, 24, 8, 5, 9, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("ccce5036-dd77-4fe9-9cfc-dac5f2159a0b"),
                Name = "Prototype Layout 13.txt",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/ccce5036-dd77-4fe9-9cfc-dac5f2159a0b.txt",
                AddedAt = new DateTime(2024, 10, 8, 1, 59, 4, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("667b30a6-2167-4394-8346-d4d3f8b894f2"),
                Name = "Service Mesh Plan 2.docx",
                Path = "uploads/users/11111111-1111-1111-1111-111111111111/files/667b30a6-2167-4394-8346-d4d3f8b894f2.docx",
                AddedAt = new DateTime(2025, 5, 18, 0, 40, 10, DateTimeKind.Utc),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("03a8b6f1-9ed8-4a77-b9d0-9827301b2408"),
                Name = "Clinical Notes 16.pptx",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/03a8b6f1-9ed8-4a77-b9d0-9827301b2408.pptx",
                AddedAt = new DateTime(2025, 8, 28, 0, 29, 31, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("f8444b9b-13d7-4aaa-abda-3cb4420f4dab"),
                Name = "Interview Feedback 12.docx",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/f8444b9b-13d7-4aaa-abda-3cb4420f4dab.docx",
                AddedAt = new DateTime(2025, 1, 10, 13, 30, 32, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("2efadb1c-bd85-4b08-81c5-e4082a3d07b8"),
                Name = "Checklist 9.txt",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/2efadb1c-bd85-4b08-81c5-e4082a3d07b8.txt",
                AddedAt = new DateTime(2024, 1, 18, 2, 22, 35, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("929994c8-e86b-4a6b-afa2-3fbf1a63662b"),
                Name = "Lecture Notes 9.pdf",
                Path = "uploads/users/666e6666-6666-6666-6666-666666666666/files/929994c8-e86b-4a6b-afa2-3fbf1a63662b.pdf",
                AddedAt = new DateTime(2025, 10, 5, 16, 54, 32, DateTimeKind.Utc),
                UserId = Guid.Parse("666e6666-6666-6666-6666-666666666666")
            },
            new
            {
                Id = Guid.Parse("506d6bfc-25ad-468a-bf89-c2dc1ce7b654"),
                Name = "Study Material 12.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/506d6bfc-25ad-468a-bf89-c2dc1ce7b654.png",
                AddedAt = new DateTime(2025, 8, 6, 9, 59, 55, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("40c12560-c27e-483c-80ed-78423683ed57"),
                Name = "Policy Statement 20.png",
                Path = "uploads/users/555e5555-5555-5555-5555-555555555555/files/40c12560-c27e-483c-80ed-78423683ed57.png",
                AddedAt = new DateTime(2024, 4, 26, 17, 0, 51, DateTimeKind.Utc),
                UserId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            }
        );
    }
}