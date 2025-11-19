using e_learning_backend.Domain.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;

public class TeacherQuestionAccessEntityTypeConfiguration : IEntityTypeConfiguration<TeacherQuestionAccess>
{
    public void Configure(EntityTypeBuilder<TeacherQuestionAccess> builder)
    {
        builder.HasKey(t => new { t.TeacherId, t.QuestionId });

        builder.HasOne(t => t.Teacher)
            .WithMany(u => u.TeacherQuestionAccesses)
            .HasForeignKey(t => t.TeacherId);

        builder.HasOne(t => t.Question)
            .WithMany(q => q.Accesses)
            .HasForeignKey(t => t.QuestionId);

        builder.HasData(
            // new
            // {
            //     TeacherId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            //     QuestionId = Guid.Parse("10000000-0000-0000-0002-000000000001"),
            //     Created = true
            // }
        );
    }
}