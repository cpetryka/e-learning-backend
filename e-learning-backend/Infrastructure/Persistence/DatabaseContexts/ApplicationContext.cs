using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Classes.ValueObjects;
using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Participations;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts;

public class ApplicationContext : DbContext
{
    protected ApplicationContext() { }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseVariant> CourseVariants { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<CourseLanguage> CourseLanguages { get; set; }
    public DbSet<CourseLevel> CourseLevels { get; set; }
    
    public DbSet<Participation> Participations { get; set; }
    
    public DbSet<Class> Classes { get; set; }
    public DbSet<ClassStatus> ClassStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        
        modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseVariantEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseCategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseLanguageEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseLevelEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new ParticipationEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new ClassEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClassStatusEntityTypeConfiguration());
    }
}