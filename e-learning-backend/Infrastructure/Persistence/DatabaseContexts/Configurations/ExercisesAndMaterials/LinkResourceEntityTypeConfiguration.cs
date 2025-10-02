using e_learning_backend.Domain.ExercisesAndMaterials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class LinkResourceEntityTypeConfiguration : IEntityTypeConfiguration<LinkResource>
{
    public void Configure(EntityTypeBuilder<LinkResource> builder)
    {
        builder.HasKey(cl => cl.Id);
        builder.Property(cl => cl.Link)
            .IsRequired()
            .HasMaxLength(500);
        
        var classId1 = Guid.Parse("43333333-3333-3333-3333-333333333333");
        var classId2 = Guid.Parse("53333333-3333-3333-3333-333333333333");
        var classId3 = Guid.Parse("63333333-3333-3333-3333-333333333333");
        var classId4 = Guid.Parse("73333333-3333-3333-3333-333333333333");
        var classId5 = Guid.Parse("83333333-3333-3333-3333-333333333333");
        var classId6 = Guid.Parse("93333333-3333-3333-3333-333333333333");
        
        builder.HasData(
            new { 
                Id = Guid.Parse("44444444-0000-0000-0000-000000000001"), 
                Link = "https://example.com/resource1", 
                ClassId = classId1,
                Date = new DateTime(2025, 10, 2, 12, 0, 0, DateTimeKind.Utc)
            },
            new { 
                Id = Guid.Parse("44444444-0000-0000-0000-000000000002"), 
                Link = "https://example.com/resource2", 
                ClassId = classId1,
                Date = new DateTime(2025, 10, 2, 12, 5, 0, DateTimeKind.Utc)
            },

            new { 
                Id = Guid.Parse("44444444-0000-0000-0000-000000000003"), 
                Link = "https://example.com/resource3", 
                ClassId = classId2,
                Date = new DateTime(2025, 10, 2, 13, 0, 0, DateTimeKind.Utc)
            },

            new { 
                Id = Guid.Parse("44444444-0000-0000-0000-000000000004"), 
                Link = "https://example.com/resource4", 
                ClassId = classId3,
                Date = new DateTime(2025, 10, 2, 14, 0, 0, DateTimeKind.Utc)
            },
            new { 
                Id = Guid.Parse("44444444-0000-0000-0000-000000000005"), 
                Link = "https://example.com/resource5", 
                ClassId = classId3,
                Date = new DateTime(2025, 10, 2, 14, 5, 0, DateTimeKind.Utc)
            },

            new { 
                Id = Guid.Parse("44444444-0000-0000-0000-000000000006"), 
                Link = "https://example.com/resource6", 
                ClassId = classId5,
                Date = new DateTime(2025, 10, 2, 15, 0, 0, DateTimeKind.Utc)
            }
        );

    }
}