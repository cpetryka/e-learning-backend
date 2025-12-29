using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SpectatorInvitesEntityTypeConfiguration : IEntityTypeConfiguration<SpectatorInvite>
{
    public void Configure(EntityTypeBuilder<SpectatorInvite> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Token)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.ExpiresAtUtc).IsRequired();

        // Shadow foreign keys:
        builder.Property<Guid>("SpectatedId");
        builder.Property<Guid>("SpectatorId");

        builder.HasOne(x => x.Spectated)
            .WithMany()
            .HasForeignKey("SpectatedId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Spectator)
            .WithMany()
            .HasForeignKey("SpectatorId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex("SpectatedId");
        builder.HasIndex("SpectatorId");
        builder.HasIndex(x => x.Token).IsUnique();
        
        builder.ToTable("SpectatorInvites");
    }
}