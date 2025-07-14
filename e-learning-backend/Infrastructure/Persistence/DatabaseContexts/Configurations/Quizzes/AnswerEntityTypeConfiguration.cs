using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Content)
            .IsRequired();

        builder.HasData(
            new
            {
                Id = Guid.Parse("20000000-0033-0000-0000-000000000001"),
                Content = "4",
                IsCorrect = true
            },
            new
            {
                Id = Guid.Parse("20000000-0033-0000-0000-000000000002"),
                Content = "5",
                IsCorrect = false
            }
        );
    }
}