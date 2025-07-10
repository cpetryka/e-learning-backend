using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseLanguageEntityTypeConfiguration : IEntityTypeConfiguration<CourseLanguage>
{
    public void Configure(EntityTypeBuilder<CourseLanguage> builder)
    {
        builder.HasKey(l => l.Id);

        var languageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28");

        builder.HasData(new CourseLanguage(languageId, "English"));
    }
}