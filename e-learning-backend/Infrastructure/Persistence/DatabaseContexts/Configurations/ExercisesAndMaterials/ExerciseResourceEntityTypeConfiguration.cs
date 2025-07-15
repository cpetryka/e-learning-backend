namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExerciseResourceEntityTypeConfiguration : IEntityTypeConfiguration<ExerciseResource>
{
    public void Configure(EntityTypeBuilder<ExerciseResource> builder)
    {
        builder.HasKey(er => new { er.ExerciseId, er.FileId });

        builder.Property(er => er.Type)
            .HasConversion<string>() // lub .HasConversion<int>() jeśli chcesz enum jako liczby
            .IsRequired();

        builder.HasOne(er => er.Exercise)
            .WithMany(e => e.ExerciseResources)
            .HasForeignKey(er => er.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(er => er.File)
            .WithMany(f => f.ExerciseResources)
            .HasForeignKey(er => er.FileId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new
        {
            ExerciseId = Guid.Parse("ee111111-1111-1111-1111-111111111111"),
            FileId = Guid.Parse("ff555555-5555-5555-5555-555555555555"),
            Type = ExerciseResourceType.Content
        });

    }
}
