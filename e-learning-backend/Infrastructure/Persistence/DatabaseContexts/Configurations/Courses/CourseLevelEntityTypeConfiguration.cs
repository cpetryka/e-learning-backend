using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseLevelEntityTypeConfiguration : IEntityTypeConfiguration<CourseLevel>
{
    public void Configure(EntityTypeBuilder<CourseLevel> builder)
    {
        builder.HasKey(l => l.Id);

        var beginnerId     = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824");
        var intermediateId = Guid.Parse("2e9d2f0b-7a5f-4c2d-9a1a-8f3f3c2e7b01");
        var advancedId     = Guid.Parse("5c4b6e1f-3a2d-4f5b-b3a6-2e1f4c7a9d22");

        builder.HasData(
            new CourseLevel(beginnerId, "Beginner"),
            new CourseLevel(intermediateId, "Intermediate"),
            new CourseLevel(advancedId, "Advanced")
        );
    }
}