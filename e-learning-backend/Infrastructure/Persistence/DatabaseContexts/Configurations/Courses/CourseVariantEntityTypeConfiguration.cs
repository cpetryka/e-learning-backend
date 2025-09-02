using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseVariantEntityTypeConfiguration : IEntityTypeConfiguration<CourseVariant>
{
    public void Configure(EntityTypeBuilder<CourseVariant> builder)
    {
        builder.HasKey(v => v.Id);

        builder.HasOne(v => v.Level)
            .WithMany()
            .HasForeignKey("CourseLevelId");

        builder.HasOne(v => v.Language)
            .WithMany()
            .HasForeignKey("CourseLanguageId");

        builder.OwnsOne(v => v.Rate, rate =>
        {
            rate.Property(r => r.Amount).HasColumnName("Rate_Amount");
        });




       // === CourseVariants ===
builder.HasData(
    new { Id = Guid.Parse("82502dbb-dd0d-436c-8973-439f54f30307"), CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28") },
    new { Id = Guid.Parse("c63947ee-b7ae-4c44-94b2-a287db4283b1"), CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("4819eeff-dbe1-435c-a24e-ddc070c546d0"), CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("42f0a604-8f4b-420a-84a5-433286d04a43"), CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28") },
    new { Id = Guid.Parse("97904238-f028-4e42-8676-5067dd3b2f48"), CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("6a3de2fa-8315-46aa-b19f-808359673d0c"), CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("7bc180c3-c93e-4cc0-b8b8-1e4736b64e5f"), CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("fe7615e2-cd45-4307-9e74-a837f2b4d606"), CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("7852b013-3d6d-43d5-9d90-45fdfcb2bf8f"), CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("b48f2853-a6ba-4065-830b-27ae5e34210d"), CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("9273eb82-04a3-402b-a47f-46c2444ed224"), CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("ea675454-f59a-4c5e-978b-a674f7d7fbaf"), CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("47a3c669-324b-436e-9105-161096e98fff"), CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("ef3d4e73-a76a-42b6-81f5-7833885d0a69"), CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("c80e3399-2d3f-40aa-8084-33260268b3ca"), CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("72e7ead9-5ed8-4eac-bbef-ff39303c1d6f"), CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("94280811-2a10-4652-98c8-976a15934229"), CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("2bb9df2c-c27b-424c-8814-7c38b00045e8"), CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("460191ad-9096-4a63-9cfd-9815081d830c"), CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("3e478559-1761-45fe-99ef-b70f930757c8"), CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("740f2c84-87fa-4d4d-97b3-35dbae1f2b8c"), CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("e1fc1975-94ce-4181-b485-0d6c05a5a1b8"), CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28") },
    new { Id = Guid.Parse("9f219956-15d4-459f-89ef-c6b833ae8adb"), CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("4dfc5a21-3a18-494c-8b23-d0f6bc67b3e5"), CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("c89fe8aa-1778-4a06-bc5f-74b646e229db"), CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("87d81047-9c6f-40df-ba59-4a6f6dde52c2"), CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28") },
    new { Id = Guid.Parse("9b77a2fb-6522-45dd-ae91-e5b84d0a3951"), CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("bab119fc-c7d6-4088-b42b-48566676a495"), CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("e643d11f-26f4-43bf-8567-886c4ef0ec73"), CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("ce899111-a22d-4cca-bd65-fcfa633754b9"), CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28") },
    new { Id = Guid.Parse("859fe465-5347-465e-b96b-af506d29cbb6"), CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("9e66b30c-0758-4fd9-ade2-0a3869fbc809"), CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("97d2f974-4d8d-410f-ad1b-4cfd8ce7bbcf"), CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("52540491-ae28-4d37-b551-9ab7883c2dd2"), CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("a415a739-5557-4d0e-8980-68bb3ba2aa7e"), CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("32637827-fe2d-4a40-9641-8b18a9df1cfb"), CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"), CourseLevelId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("23b606d1-db8b-4008-a7fc-4b3b00ced664"), CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("d67a7dbd-f931-4702-ac9d-cb364bb3993f"), CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("658add93-5b81-4dff-94ff-6ca82d7da6f9"), CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") },
    new { Id = Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2"), CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb"), CourseLevelId = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22"), CourseLanguageId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2") },
    new { Id = Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178"), CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0"), CourseLevelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824"), CourseLanguageId = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10") }
);

// === CourseRates ===
builder.OwnsOne(v => v.Rate).HasData(
    new { CourseVariantId = Guid.Parse("82502dbb-dd0d-436c-8973-439f54f30307"), Amount = 55m },
    new { CourseVariantId = Guid.Parse("c63947ee-b7ae-4c44-94b2-a287db4283b1"), Amount = 60m },
    new { CourseVariantId = Guid.Parse("4819eeff-dbe1-435c-a24e-ddc070c546d0"), Amount = 65m },
    new { CourseVariantId = Guid.Parse("42f0a604-8f4b-420a-84a5-433286d04a43"), Amount = 70m },
    new { CourseVariantId = Guid.Parse("97904238-f028-4e42-8676-5067dd3b2f48"), Amount = 75m },
    new { CourseVariantId = Guid.Parse("6a3de2fa-8315-46aa-b19f-808359673d0c"), Amount = 80m },
    new { CourseVariantId = Guid.Parse("7bc180c3-c93e-4cc0-b8b8-1e4736b64e5f"), Amount = 85m },
    new { CourseVariantId = Guid.Parse("fe7615e2-cd45-4307-9e74-a837f2b4d606"), Amount = 90m },
    new { CourseVariantId = Guid.Parse("7852b013-3d6d-43d5-9d90-45fdfcb2bf8f"), Amount = 95m },
    new { CourseVariantId = Guid.Parse("b48f2853-a6ba-4065-830b-27ae5e34210d"), Amount = 100m },
    new { CourseVariantId = Guid.Parse("9273eb82-04a3-402b-a47f-46c2444ed224"), Amount = 105m },
    new { CourseVariantId = Guid.Parse("ea675454-f59a-4c5e-978b-a674f7d7fbaf"), Amount = 110m },
    new { CourseVariantId = Guid.Parse("47a3c669-324b-436e-9105-161096e98fff"), Amount = 115m },
    new { CourseVariantId = Guid.Parse("ef3d4e73-a76a-42b6-81f5-7833885d0a69"), Amount = 120m },
    new { CourseVariantId = Guid.Parse("c80e3399-2d3f-40aa-8084-33260268b3ca"), Amount = 125m },
    new { CourseVariantId = Guid.Parse("72e7ead9-5ed8-4eac-bbef-ff39303c1d6f"), Amount = 130m },
    new { CourseVariantId = Guid.Parse("94280811-2a10-4652-98c8-976a15934229"), Amount = 135m },
    new { CourseVariantId = Guid.Parse("2bb9df2c-c27b-424c-8814-7c38b00045e8"), Amount = 140m },
    new { CourseVariantId = Guid.Parse("460191ad-9096-4a63-9cfd-9815081d830c"), Amount = 145m },
    new { CourseVariantId = Guid.Parse("3e478559-1761-45fe-99ef-b70f930757c8"), Amount = 150m },
    new { CourseVariantId = Guid.Parse("740f2c84-87fa-4d4d-97b3-35dbae1f2b8c"), Amount = 155m },
    new { CourseVariantId = Guid.Parse("e1fc1975-94ce-4181-b485-0d6c05a5a1b8"), Amount = 160m },
    new { CourseVariantId = Guid.Parse("9f219956-15d4-459f-89ef-c6b833ae8adb"), Amount = 165m },
    new { CourseVariantId = Guid.Parse("4dfc5a21-3a18-494c-8b23-d0f6bc67b3e5"), Amount = 170m },
    new { CourseVariantId = Guid.Parse("c89fe8aa-1778-4a06-bc5f-74b646e229db"), Amount = 175m },
    new { CourseVariantId = Guid.Parse("87d81047-9c6f-40df-ba59-4a6f6dde52c2"), Amount = 180m },
    new { CourseVariantId = Guid.Parse("9b77a2fb-6522-45dd-ae91-e5b84d0a3951"), Amount = 185m },
    new { CourseVariantId = Guid.Parse("bab119fc-c7d6-4088-b42b-48566676a495"), Amount = 190m },
    new { CourseVariantId = Guid.Parse("e643d11f-26f4-43bf-8567-886c4ef0ec73"), Amount = 195m },
    new { CourseVariantId = Guid.Parse("ce899111-a22d-4cca-bd65-fcfa633754b9"), Amount = 200m },
    new { CourseVariantId = Guid.Parse("859fe465-5347-465e-b96b-af506d29cbb6"), Amount = 205m },
    new { CourseVariantId = Guid.Parse("9e66b30c-0758-4fd9-ade2-0a3869fbc809"), Amount = 210m },
    new { CourseVariantId = Guid.Parse("97d2f974-4d8d-410f-ad1b-4cfd8ce7bbcf"), Amount = 215m },
    new { CourseVariantId = Guid.Parse("52540491-ae28-4d37-b551-9ab7883c2dd2"), Amount = 220m },
    new { CourseVariantId = Guid.Parse("a415a739-5557-4d0e-8980-68bb3ba2aa7e"), Amount = 225m },
    new { CourseVariantId = Guid.Parse("32637827-fe2d-4a40-9641-8b18a9df1cfb"), Amount = 230m },
    new { CourseVariantId = Guid.Parse("23b606d1-db8b-4008-a7fc-4b3b00ced664"), Amount = 235m },
    new { CourseVariantId = Guid.Parse("d67a7dbd-f931-4702-ac9d-cb364bb3993f"), Amount = 240m },
    new { CourseVariantId = Guid.Parse("658add93-5b81-4dff-94ff-6ca82d7da6f9"), Amount = 245m },
    new { CourseVariantId = Guid.Parse("adf06fe9-868c-454a-ab23-0a646d3590e2"), Amount = 250m },
    new { CourseVariantId = Guid.Parse("6b5b4010-c79b-4913-a488-21c3a83b3178"), Amount = 255m }
);

    }
}