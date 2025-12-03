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
            .WithOne(v => v.Course)
            .HasForeignKey(v => v.CourseId);

        builder.HasOne(c => c.Teacher)
            .WithMany(u => u.ConductedCourses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);


        // Kategorie (muszą pasować do tych z CourseCategoryEntityTypeConfiguration)
        var programmingId = Guid.Parse("92625ae5-da0e-48ce-ac3f-79f9be35caa4");
        var mathId = Guid.Parse("8c38a9f6-88a5-4c24-ae9b-6b6ef1b29101");
        var physicsId = Guid.Parse("1a2b7d4f-5f33-42f7-84c7-d8b63b1ff903");
        var chemistryId = Guid.Parse("e0e02d97-d1d7-4b65-b3d5-41b35b5c5d32");
        var biologyId = Guid.Parse("0e69a35d-f6a4-4a3f-9a5e-3b7ff3d61f1b");
        var historyId = Guid.Parse("a7a1c6f0-f2c2-442f-b01a-8f5dd61e2a33");
        var literatureId = Guid.Parse("d32cf0a4-4f55-41e8-8e3a-6d6d1fb469fd");
        var languagesId = Guid.Parse("8b6f5a54-5de8-4c8e-bf26-9f7ab6f22bb0");
        var artId = Guid.Parse("c9c98c2f-0e6e-4a8a-bb4f-b44c442e9f5c");
        var musicId = Guid.Parse("6d402e25-2a83-47f3-96c6-0a8e7c8ec5d4");

        // Nauczyciele (pasują do UserEntityTypeConfiguration)
        var teacherId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var teacher2Id = Guid.Parse("555e5555-5555-5555-5555-555555555555");
        var teacher3Id = Guid.Parse("666e6666-6666-6666-6666-666666666666");


        builder.HasData(
            new
            {
                Id = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"),
                Name = "C# Basics",
                Description = "Learn the basics of C# programming.",
                CategoryId = programmingId,
                TeacherId = teacherId
            },
            new
            {
                Id = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"),
                Name = "Advanced Java",
                Description = "Deep dive into advanced Java topics.",
                CategoryId = programmingId,
                TeacherId = teacher2Id
            },
            new
            {
                Id = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"),
                Name = "Web Development with React",
                Description = "Build modern web applications using React.",
                CategoryId = programmingId,
                TeacherId = teacher3Id
            },
            new
            {
                Id = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"),
                Name = "Calculus I",
                Description = "Introduction to limits, derivatives, and integrals.",
                CategoryId = mathId,
                TeacherId = teacherId
            },
            new
            {
                Id = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d"),
                Name = "Linear Algebra",
                Description = "Learn vectors, matrices, and transformations.",
                CategoryId = mathId,
                TeacherId = teacher2Id
            },
            new
            {
                Id = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"),
                Name = "Quantum Physics",
                Description = "Explore the fundamentals of quantum mechanics.",
                CategoryId = physicsId,
                TeacherId = teacher3Id
            },
            new
            {
                Id = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2"),
                Name = "Classical Mechanics",
                Description = "Newtonian mechanics and laws of motion.",
                CategoryId = physicsId,
                TeacherId = teacherId
            },
            new
            {
                Id = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3"),
                Name = "Organic Chemistry",
                Description = "Understand the structure and reactions of organic molecules.",
                CategoryId = chemistryId,
                TeacherId = teacher2Id
            },
            new
            {
                Id = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71"),
                Name = "Inorganic Chemistry",
                Description = "Introduction to inorganic compounds and reactions.",
                CategoryId = chemistryId,
                TeacherId = teacher3Id
            },
            new
            {
                Id = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"),
                Name = "Cell Biology",
                Description = "Study the structure and function of cells.",
                CategoryId = biologyId,
                TeacherId = teacherId
            },
            new
            {
                Id = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"),
                Name = "Genetics",
                Description = "Learn the principles of heredity and DNA.",
                CategoryId = biologyId,
                TeacherId = teacher2Id
            },
            new
            {
                Id = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15"),
                Name = "World History",
                Description = "Explore major events from ancient to modern times.",
                CategoryId = historyId,
                TeacherId = teacher3Id
            },
            new
            {
                Id = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f"),
                Name = "English Literature",
                Description = "Dive into Shakespeare and other English classics.",
                CategoryId = literatureId,
                TeacherId = teacherId
            },
            new
            {
                Id = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"),
                Name = "Spanish for Beginners",
                Description = "Start speaking and understanding basic Spanish.",
                CategoryId = languagesId,
                TeacherId = teacher2Id
            },
            new
            {
                Id = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb"),
                Name = "Digital Painting",
                Description = "Learn techniques of painting with digital tools.",
                CategoryId = artId,
                TeacherId = teacher3Id
            },
            new
            {
                Id = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0"),
                Name = "Piano for Beginners",
                Description = "Play your first songs on the piano.",
                CategoryId = musicId,
                TeacherId = teacherId
            }
        );

        builder.OwnsOne(u => u.ProfilePicture, pp =>
        {
            pp.Property(p => p.FileName)
                .HasMaxLength(255)
                .HasColumnName("ProfilePictureFileName");

            pp.Property(p => p.FilePath)
                .HasMaxLength(500)
                .HasColumnName("ProfilePictureFilePath");

            pp.Property(p => p.UploadedAt)
                .HasColumnName("ProfilePictureUploadedAt");

            pp.HasData(
                new
                {
                    CourseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\0042b980-d8cc-4969-af0f-62d8c1632871\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("c29ad7cb-dede-4ff6-b119-70dbad602f90"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\c29ad7cb-dede-4ff6-b119-70dbad602f90\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\f31eb3f2-643d-4b31-9f8f-d7aaf6e0e6cd\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("e4c2a925-fc12-4827-a9e2-df87cc7c12e0"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\e4c2a925-fc12-4827-a9e2-df87cc7c12e0\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("99d1436e-0028-4b8e-b949-fcf33fc43e2d"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\99d1436e-0028-4b8e-b949-fcf33fc43e2d\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("f5f9237d-5ff5-439a-86c5-10c66cb2d9e6"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\f5f9237d-5ff5-439a-86c5-10c66cb2d9e6\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("7f3d823c-b6ab-497f-8cc9-30b0f80d68f2"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\7f3d823c-b6ab-497f-8cc9-30b0f80d68f2\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\d1b85095-dcb3-4ec6-b0c6-1a0c5b47d8a3\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("6e3a3c34-f40c-4d90-a986-588b17867b71"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\6e3a3c34-f40c-4d90-a986-588b17867b71\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("fb003b55-b775-45b1-8f3c-568c4e7e8d40"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\fb003b55-b775-45b1-8f3c-568c4e7e8d40\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("78f0e23b-1b9a-4b07-9191-7f2f332e3ee8"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\78f0e23b-1b9a-4b07-9191-7f2f332e3ee8\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\a0e86a5c-82b0-4ef8-9492-7d9a8e1e0d15\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("44d62488-947d-41e1-a1dd-7de74ff7aa8f"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\44d62488-947d-41e1-a1dd-7de74ff7aa8f\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("b9427e4d-34e6-48c5-943f-94e3f2f6891c"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\b9427e4d-34e6-48c5-943f-94e3f2f6891c\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\b13306f3-05fd-4f45-bdeb-8b3f9e90a4bb\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                },
                new
                {
                    CourseId = Guid.Parse("b39f4f06-84e4-45c0-a3a0-b59334c8f8d0"),
                    FileName = "profile-picture.jpg",
                    FilePath = @"uploads\courses\b39f4f06-84e4-45c0-a3a0-b59334c8f8d0\profile-picture.jpg",
                    UploadedAt = DateTime.SpecifyKind(DateTime.Parse("2025-10-07 11:35:00"), DateTimeKind.Utc)
                }
            );
        });
    }
}