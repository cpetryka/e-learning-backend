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
    new { Id = Guid.Parse("363dbc8e-4b8d-4e38-8056-8fbec5189595"), Date = new DateTime(2025, 9, 18, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("afd94d23-e3bc-4c68-9280-5dddcd095114"), Date = new DateTime(2025, 9, 24, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("766cbd0a-fc15-4ee8-8ff6-88575fa82588"), Date = new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("3eae88d0-d949-490a-aee4-cc7fac2e6f3a"), Date = new DateTime(2025, 8, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("0e878798-e7ff-40b4-87d3-6ecaf5fb2988"), Date = new DateTime(2025, 9, 19, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("09c0e238-2192-46d7-b56d-ad67d93bf334"), Date = new DateTime(2025, 9, 25, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("77ce9813-d6f7-4790-b85a-0fc6a5bcc778"), Date = new DateTime(2025, 9, 20, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("4da95572-ef28-4601-924d-d0a9821464a2"), Date = new DateTime(2025, 8, 29, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("3f9ba179-5f11-4f79-9df1-78437f7f8f18"), Date = new DateTime(2025, 9, 8, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("1a425015-f406-4c0a-8c12-bd2ce3f518f3"), Date = new DateTime(2025, 9, 7, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("01ee1fb8-8a12-4527-93f6-26c4dcb994f3"), Date = new DateTime(2025, 8, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("be1f20e1-c0ac-430b-9a90-6db264dc3f4e"), Date = new DateTime(2025, 9, 29, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("444b0ed9-cb6c-4814-ad94-97ed87d63694"), Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("8bc9063b-6ddf-49f6-9e4c-be111e0c87f3"), Date = new DateTime(2025, 9, 21, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("4f764b99-b075-49bb-ab2d-4e8179423559"), Date = new DateTime(2025, 9, 16, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("98f87798-fce0-43ef-ab6c-ee958ad4589c"), Date = new DateTime(2025, 9, 10, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("1fece1c1-3bc6-4b3c-854a-4132f49127b0"), Date = new DateTime(2025, 9, 10, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("b95e205e-bd9c-4d55-9e8e-f37f0b370331"), Date = new DateTime(2025, 8, 28, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("9700d217-06ab-4a57-b4d6-9bb9c3747ee8"), Date = new DateTime(2025, 9, 14, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("3116b900-1d45-49dc-956e-5bac45b463e4"), Date = new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("a999c952-a96d-4702-adc9-b1825855bf91"), Date = new DateTime(2025, 9, 19, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("c783623f-e04f-4ad7-a5d1-24b7e8dba62c"), Date = new DateTime(2025, 9, 15, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("41f7c59c-d75a-4c7c-aea4-ac80d1dbb740"), Date = new DateTime(2025, 9, 24, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("37a7442a-111d-403b-ae86-3eee9e611362"), Date = new DateTime(2025, 9, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("526deab2-56b1-4531-b149-e7d8f7efa055"), Date = new DateTime(2025, 9, 21, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("9f2696f6-2d3f-4b4e-8374-12bd74db2122"), Date = new DateTime(2025, 9, 9, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("5d543b22-de3a-4add-ad8a-cfa263ca2193"), Date = new DateTime(2025, 9, 8, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("5aae1ef6-ae09-4e00-a75b-9bd5b25acedf"), Date = new DateTime(2025, 9, 3, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("ccb15ba8-eaf9-4c7d-bd44-cbe0d8f71b98"), Date = new DateTime(2025, 9, 26, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("0606988b-a634-4bb0-80d8-f08dfd112b6b"), Date = new DateTime(2025, 9, 6, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("152d3c66-4268-4d24-a56d-956fedd2e2c3"), Date = new DateTime(2025, 9, 18, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("21ff9c11-e4c3-4e0e-881f-0ec527336d19"), Date = new DateTime(2025, 9, 17, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("f0c94f8b-8cfe-40a0-9bb5-a773bef76697"), Date = new DateTime(2025, 9, 20, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("21c8458e-39a5-4970-95be-e75d068860e0"), Date = new DateTime(2025, 8, 31, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("2557a22b-702f-4fff-b66b-23cf9fcaf8f8"), Date = new DateTime(2025, 8, 31, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("4168463f-a19b-49d2-83b2-ba8c4565615d"), Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("3bba12fb-beeb-4d07-9d1d-9374c3b71c22"), Date = new DateTime(2025, 9, 10, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("07a29fe9-5ba6-4575-b4ae-80795b424f39"), Date = new DateTime(2025, 9, 6, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("829abe1f-c5ab-4b57-b7d8-ca138259d4f2"), Date = new DateTime(2025, 8, 27, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("92addb21-2206-433e-abb4-54e1ee2981ac"), Date = new DateTime(2025, 9, 29, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("0a61e659-6f36-433c-87d8-c473ba6ee91b"), Date = new DateTime(2025, 9, 25, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("90f02620-5322-4820-8499-49420b9eb13f"), Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("f466f13f-afca-4caa-9fe1-9df47979f802"), Date = new DateTime(2025, 9, 23, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("b18ae40a-9154-42de-8ce5-d26e4a7d931d"), Date = new DateTime(2025, 8, 31, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("a9309457-bb18-419e-bed3-39df790a4655"), Date = new DateTime(2025, 9, 16, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") },
    new { Id = Guid.Parse("cb2c36cb-0602-4a2a-81fe-77f938b76f05"), Date = new DateTime(2025, 9, 16, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("3be9e8b6-8bde-447c-adbd-0b3da94b0fe8"), Date = new DateTime(2025, 9, 12, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new { Id = Guid.Parse("abd886ed-5cdc-4402-bfaa-1995416280f6"), Date = new DateTime(2025, 9, 7, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("0822dc10-2cfe-4a58-86c1-171182bbd5a6"), Date = new DateTime(2025, 9, 11, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555") },
    new { Id = Guid.Parse("6dd8433d-0ea2-4c0e-b1d3-b05562ffcd5f"), Date = new DateTime(2025, 9, 12, 0, 0, 0, DateTimeKind.Utc), TeacherId = Guid.Parse("666e6666-6666-6666-6666-666666666666") }
);

    }
}