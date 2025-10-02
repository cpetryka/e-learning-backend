using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Classes.ValueObjects;
using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Participations;
using e_learning_backend.Domain.Quizzes;
using e_learning_backend.Domain.Users;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts;

public class ApplicationContext : DbContext
{
    protected ApplicationContext() { }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Availability> Availabilities { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseVariant> CourseVariants { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<CourseLanguage> CourseLanguages { get; set; }
    public DbSet<CourseLevel> CourseLevels { get; set; }
    
    public DbSet<Participation> Participations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Class> Classes { get; set; }
    public DbSet<ClassStatus> ClassStatuses { get; set; }
    
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<FileResource> FileResources { get; set; }
    public DbSet<ExerciseResource> ExerciseResources { get; set; }
    public DbSet<LinkResource> LinkResources { get; set; }
    public DbSet<Tag> Tags { get; set; }
    
    public DbSet<QuestionCategory> QuestionCategories { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<TeacherQuestionAccess> TeacherQuestionAccesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        modelBuilder.ApplyConfiguration(new AvailabilityEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TimeSlotEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseVariantEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseCategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseLanguageEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CourseLevelEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new ParticipationEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new ClassEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClassStatusEntityTypeConfiguration());
        
        modelBuilder.ApplyConfiguration(new ExerciseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new FileResourceEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseResourceEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LinkResourceEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new QuestionCategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new QuizEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherQuestionAccessEntityTypeConfiguration());
    }
}