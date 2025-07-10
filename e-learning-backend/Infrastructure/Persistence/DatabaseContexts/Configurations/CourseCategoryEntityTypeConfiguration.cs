using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseCategoryEntityTypeConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.HasKey(c => c.Id);

        var categoryId = Guid.Parse("92625ae5-da0e-48ce-ac3f-79f9be35caa4");

        builder.HasData(new CourseCategory(categoryId, "Programming"));
    }
}