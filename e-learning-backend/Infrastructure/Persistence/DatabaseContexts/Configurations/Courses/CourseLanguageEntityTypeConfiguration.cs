using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseLanguageEntityTypeConfiguration : IEntityTypeConfiguration<CourseLanguage>
{
    public void Configure(EntityTypeBuilder<CourseLanguage> builder)
    {
        builder.HasKey(l => l.Id);

        var englishId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28");
        var polishId  = Guid.Parse("7f5a44c3-3e36-4207-b8f4-1d28c0c5ad10");
        var deutschId = Guid.Parse("ad81e13e-5f9b-4ac2-bdbe-58c0c6bcb8d2");

        builder.HasData(
            new CourseLanguage(englishId, "English"),
            new CourseLanguage(polishId, "Polish"),
            new CourseLanguage(deutschId, "Deutsch")
        );
    }
}