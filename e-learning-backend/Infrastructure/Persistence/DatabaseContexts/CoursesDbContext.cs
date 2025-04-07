using e_learning_backend.Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts;

public class CoursesDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseVariant> CourseVariants { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<CourseLanguage> CourseLanguages { get; set; }
    public DbSet<CourseLevel> CourseLevels { get; set; }

    protected CoursesDbContext() { }
    public CoursesDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Course
        modelBuilder.Entity<Course>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Variants)
            .WithOne()
            .HasForeignKey("CourseId");

        // CourseVariant
        modelBuilder.Entity<CourseVariant>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<CourseVariant>()
            .HasOne(v => v.Level)
            .WithMany()
            .HasForeignKey("CourseLevelId");

        modelBuilder.Entity<CourseVariant>()
            .HasOne(v => v.Language)
            .WithMany()
            .HasForeignKey("CourseLanguageId");

        modelBuilder.Entity<CourseVariant>()
            .OwnsOne(v => v.Rate); // Value Object (no FK/table)

        // CourseCategory
        modelBuilder.Entity<CourseCategory>().HasKey(c => c.Id);
        modelBuilder.Entity<CourseLanguage>().HasKey(l => l.Id);
        modelBuilder.Entity<CourseLevel>().HasKey(l => l.Id);

        // Seed data
        var categoryId = Guid.Parse("92625ae5-da0e-48ce-ac3f-79f9be35caa4");
        var levelId = Guid.Parse("1dcb1002-ec77-49ea-8f21-56e0caac0824");
        var languageId = Guid.Parse("3e118082-c17c-4a4c-945a-1a88733c2e28");
        var courseId = Guid.Parse("0042b980-d8cc-4969-af0f-62d8c1632871");
        var variantId = Guid.Parse("4f0da3ec-6a56-4705-b691-8890b67d24b1");

        modelBuilder.Entity<CourseCategory>().HasData(new CourseCategory(categoryId, "Programming"));
        modelBuilder.Entity<CourseLevel>().HasData(new CourseLevel(levelId, "Beginner"));
        modelBuilder.Entity<CourseLanguage>().HasData(new CourseLanguage(languageId, "English"));

        modelBuilder.Entity<Course>().HasData(new
        {
            Id = courseId,
            Name = "C# Basics",
            Description = "Learn the basics of C# programming.",
            CategoryId = categoryId
        });

        modelBuilder.Entity<CourseVariant>().HasData(new
        {
            Id = variantId,
            CourseId = courseId,
            CourseLevelId = levelId,
            CourseLanguageId = languageId,
            Rate_Amount = 100m
        });
    }
}