using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Variants)
            .WithOne()
            .HasForeignKey("CourseId");
        
        builder.HasOne(c => c.Teacher)
            .WithMany(u => u.ConductedCourses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        var categoryId = Guid.Parse("92625ae5-da0e-48ce-ac3f-79f9be35caa4");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");
        var teacherId= Guid.Parse("11111111-1111-1111-1111-111111111111");

        builder.HasData(new
        {
            Id = courseId,
            Name = "C# Basics",
            Description = "Learn the basics of C# programming.",
            CategoryId = categoryId,
            TeacherId = teacherId
        });
    }
}