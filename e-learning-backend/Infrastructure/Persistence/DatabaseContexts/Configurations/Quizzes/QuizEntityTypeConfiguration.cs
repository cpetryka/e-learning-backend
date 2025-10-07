using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class QuizEntityTypeConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Class)
            .WithMany(c => c.Quizzes)
            .HasForeignKey(q => q.ClassId);

        builder.HasData(
            new
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                MultipleChoice = true,
                ClassId = Guid.Parse("58752bc5-b060-489f-8bca-4649dd909668")
            }
        );
    }
}