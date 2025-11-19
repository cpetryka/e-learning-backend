using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class QuestionCategoryEntityTypeConfiguration : IEntityTypeConfiguration<QuestionCategory>
{
    public void Configure(EntityTypeBuilder<QuestionCategory> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();

        builder.Property(c => c.Description)
            .IsRequired();

        builder.HasOne(c => c.Teacher)
            .WithMany(t => t.QuestionCategories)
            .HasForeignKey(c => c.TeacherId);

        builder.HasData(
            new
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                Name = "Math",
                Description = "Basic math questions",
                TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("ce85b81c-c05c-4d6c-934f-60618ccd83ac"),
                Name = "Physics",
                Description = "Basic physics questions",
                TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("c4b84c86-1e1c-4bd9-b641-a100f007fba0"),
                Name = "Biology",
                Description = "Introductory biology content",
                TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("bcc10097-bc45-4891-a11e-45f885c94db2"),
                Name = "Chemistry",
                Description = "General chemistry knowledge",
                TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new
            {
                Id = Guid.Parse("a0f90520-a9f7-4e79-8b99-3b4c1eb5f038"),
                Name = "History",
                Description = "Major historical events",
                TeacherId = Guid.Parse("555e5555-5555-5555-5555-555555555555")
            },
            new
            {
                Id = Guid.Parse("21189d2b-64fb-465d-8e50-6279732af8a1"),
                Name = "Programming",
                Description = "Basics of programming",
                TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            }
        );
    }
}