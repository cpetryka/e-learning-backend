using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Classes.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_learning_backend.Infrastructure.Persistence.DatabaseContexts.Configurations;

public class ClassStatusEntityTypeConfiguration : IEntityTypeConfiguration<ClassStatus>
{
    public void Configure(EntityTypeBuilder<ClassStatus> builder)
    {
        builder.HasKey(s => s.Id);

        var statusScheduledId = Guid.Parse("41111111-1111-1111-1111-111111111111");
        var statusDoneId = Guid.Parse("42222222-2222-2222-2222-222222222222");

        builder.HasData(
            new ClassStatus(statusScheduledId, "Scheduled"),
            new ClassStatus(statusDoneId, "Done")
        );
    }
}