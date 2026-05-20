using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class AudioTrackConfiguration : IEntityTypeConfiguration<AudioTrack>
{
    public void Configure(EntityTypeBuilder<AudioTrack> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => new { x.SheikhId, x.SurahId, x.QiraaId }).IsUnique();
        builder.HasIndex(x => x.SurahId);
        builder.HasIndex(x => x.QiraaId);
        builder.HasIndex(x => x.Status);

        builder.Property(x => x.TitleArabic).HasMaxLength(600).IsRequired();
        builder.Property(x => x.AudioObjectKey).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Format).HasMaxLength(50);
        builder.Property(x => x.Checksum).HasMaxLength(200);
    }
}
