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
            }
        );
    }
}