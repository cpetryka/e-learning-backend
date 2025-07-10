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

        builder.OwnsOne(v => v.Rate);

        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");
        var levelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824");
        var languageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28");
        var variantId = Guid.Parse("4f0da3ec-6a56-4705-b691-8890b67d24b1");

        builder.HasData(new
        {
            Id = variantId,
            CourseId = courseId,
            CourseLevelId = levelId,
            CourseLanguageId = languageId,
            Rate_Amount = 100m
        });
    }
}