using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Content)
            .IsRequired();
        
        builder
            .HasMany(q => q.Answers)
            .WithMany(a => a.Questions)
            .UsingEntity<Dictionary<string, object>>(
                "QuestionAnswers",
                j => j.HasOne<Answer>().WithMany().HasForeignKey("AnswerId"),
                j => j.HasOne<Question>().WithMany().HasForeignKey("QuestionId"),
                j =>
                {
                    j.HasKey("QuestionId", "AnswerId");
                    j.HasData(
                        new {
                            QuestionId = Guid.Parse("10000000-0000-0000-0002-000000000001"),
                            AnswerId = Guid.Parse("20000000-0033-0000-0000-000000000001")
                        },
                        new {
                            QuestionId = Guid.Parse("10000000-0000-0000-0002-000000000001"),
                            AnswerId = Guid.Parse("20000000-0033-0000-0000-000000000002")
                        });
                });

        
        
        /*builder
            .HasMany(q => q.Categories)
            .WithMany(c => c.Questions)
            .UsingEntity(j =>
            {
                j.ToTable("QuestionCategoryAssignments");

                j.HasData(new
                {
                    QuestionCategoryId = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    QuestionId = Guid.Parse("10000000-0000-0000-0002-000000000001")
                });
            });*/


        builder.HasMany(q => q.Categories)
            .WithMany(qc => qc.Questions)
            .UsingEntity<Dictionary<string, object>>(
                "QuestionCategoryAssignments",
                j => j
                    .HasOne<QuestionCategory>()
                    .WithMany()
                    .HasForeignKey("QuestionCategoryId"),
                j => j
                    .HasOne<Question>()
                    .WithMany()
                    .HasForeignKey("QuestionId"),
                j =>
                {
                    j.HasKey("QuestionId", "QuestionCategoryId");
                    j.HasData(new
                    {
                        QuestionId = Guid.Parse("10000000-0000-0000-0002-000000000001"),
                        QuestionCategoryId = Guid.Parse("30000000-0000-0000-0000-000000000001")
                    });
                });

        builder
            .HasMany(q => q.Quizzes)
            .WithMany(qz => qz.Questions)
            .UsingEntity<Dictionary<string, object>>(
                "QuizQuestions",
                j => j.HasOne<Quiz>().WithMany().HasForeignKey("QuizId"),
                j => j.HasOne<Question>().WithMany().HasForeignKey("QuestionId"),
                j =>
                {
                    j.HasKey("QuizId", "QuestionId");
                    j.HasData(new
                    {
                        QuizId = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                        QuestionId = Guid.Parse("10000000-0000-0000-0002-000000000001")
                    });
                });

        builder.HasMany(q => q.Accesses)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        builder.HasData(
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0002-000000000001"),
                Content = "What is 2 + 2?"
            }
        );
    }
}