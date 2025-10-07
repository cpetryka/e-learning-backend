namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        // Relacja 1..* z User (Teacher)
        builder.HasOne(t => t.Teacher)
            .WithMany(u => u.Tags)
            .HasForeignKey(t => t.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacja wiele-do-wielu z FileResource
        builder.HasMany(t => t.Files)
            .WithMany(f => f.Tags)
            .UsingEntity<Dictionary<string, object>>(
                "TagFile",
                j => j
                    .HasOne<FileResource>()
                    .WithMany()
                    .HasForeignKey("FileResourceId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("TagId", "FileResourceId");
                    j.ToTable("TagFiles");
                    
                    j.HasData(
                        new
                        {
                            TagId = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), // Matematyka
                            FileResourceId = Guid.Parse("ff555555-5555-5555-5555-555553555555")
                        }
                    );
                }
            );
        
        // Przykladowe dane
        var teacherId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        builder.HasData(
            new 
            {
                Id = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Matematyka",
                TeacherId = teacherId
            },
            new 
            {
                Id = Guid.Parse("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Fizyka",
                TeacherId = teacherId
            },
            new 
            {
                Id = Guid.Parse("aaaaaaa3-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Chemia"
            }
        );
    }
}
