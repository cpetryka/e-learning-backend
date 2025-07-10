using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseLevelEntityTypeConfiguration : IEntityTypeConfiguration<CourseLevel>
{
    public void Configure(EntityTypeBuilder<CourseLevel> builder)
    {
        builder.HasKey(l => l.Id);

        var levelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824");

        builder.HasData(new CourseLevel(levelId, "Beginner"));
    }
}