namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FileResourceEntityTypeConfiguration : IEntityTypeConfiguration<FileResource>
{
    public void Configure(EntityTypeBuilder<FileResource> builder)
    {
        builder.HasKey(fr => fr.Id);

        builder.Property(fr => fr.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(fr => fr.Path)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(fr => fr.AddedAt)
            .IsRequired();

        builder.HasOne(fr => fr.User)
            .WithMany(u => u.Files)
            .HasForeignKey(fr => fr.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasData(new
        {
            Id = Guid.Parse("ff555555-5555-5555-5555-555555555555"),
            Name = "example.pdf",
            Path = "/uploads/example.pdf",
            AddedAt = new DateTime(2025, 7, 11, 10, 0, 0, DateTimeKind.Utc),
            UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        });
    }
}
