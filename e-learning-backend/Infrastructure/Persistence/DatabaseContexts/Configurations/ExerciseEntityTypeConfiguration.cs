using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExerciseEntityTypeConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Instruction)
            .HasMaxLength(1000); // Optional limit

        builder.Property(e => e.Grade)
            .HasPrecision(3, 2); // For example: allow grades like 4.50

        builder.Property(e => e.Comment)
            .HasMaxLength(1000);

        builder.Property(e => e.Status)
            .HasConversion<string>() // Store enum as string, or use int if preferred
            .IsRequired();

        builder.HasOne(e => e.Class)
            .WithMany(c => c.Exercises)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Cascade); // Optional
        
        builder.HasMany(e => e.ExerciseResources)
            .WithOne(er => er.Exercise)
            .HasForeignKey(er => er.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Sample seed (optional)
        builder.HasData(new
        {
            Id = Guid.Parse("ee111111-1111-1111-1111-111111111111"),
            Instruction = "Complete the assignment on OOP concepts.",
            Grade = 4.50,
            Comment = "Good job on the assignment!",
            Status = ExerciseStatus.Graded,
            ClassId = Guid.Parse("43333333-3333-3333-3333-333333333333")
        });
    }
}