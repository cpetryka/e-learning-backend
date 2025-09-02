using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class CourseCategoryEntityTypeConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasData(
            new CourseCategory(Guid.Parse("92625ae5-da0e-48ce-ac3f-79f9be35caa4"), "Programming"),
            new CourseCategory(Guid.Parse("8c38a9f6-88a5-4c24-ae9b-6b6ef1b29101"), "Mathematics"),
            new CourseCategory(Guid.Parse("1a2b7d4f-5f33-42f7-84c7-d8b63b1ff903"), "Physics"),
            new CourseCategory(Guid.Parse("e0e02d97-d1d7-4b65-b3d5-41b35b5c5d32"), "Chemistry"),
            new CourseCategory(Guid.Parse("0e69a35d-f6a4-4a3f-9a5e-3b7ff3d61f1b"), "Biology"),
            new CourseCategory(Guid.Parse("a7a1c6f0-f2c2-442f-b01a-8f5dd61e2a33"), "History"),
            new CourseCategory(Guid.Parse("d32cf0a4-4f55-41e8-8e3a-6d6d1fb469fd"), "Literature"),
            new CourseCategory(Guid.Parse("8b6f5a54-5de8-4c8e-bf26-9f7ab6f22bb0"), "Languages"),
            new CourseCategory(Guid.Parse("c9c98c2f-0e6e-4a8a-bb4f-b44c442e9f5c"), "Art & Design"),
            new CourseCategory(Guid.Parse("6d402e25-2a83-47f3-96c6-0a8e7c8ec5d4"), "Music")
        );
    }
}