using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class AyahTimingConfiguration : IEntityTypeConfiguration<AyahTiming>
{
    public void Configure(EntityTypeBuilder<AyahTiming> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => new { x.AudioTrackId, x.AyahId }).IsUnique();

        builder.HasOne(x => x.AudioTrack)
            .WithMany(x => x.AyahTimings)
            .HasForeignKey(x => x.AudioTrackId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Ayah)
            .WithMany(x => x.Timings)
            .HasForeignKey(x => x.AyahId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
