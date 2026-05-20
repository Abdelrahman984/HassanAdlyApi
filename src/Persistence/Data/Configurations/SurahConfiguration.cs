using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SurahConfiguration : IEntityTypeConfiguration<Surah>
{
    public void Configure(EntityTypeBuilder<Surah> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.NameArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.NameTransliteration).HasMaxLength(200).IsRequired();
        builder.Property(x => x.NameEnglish).HasMaxLength(200);
        builder.Property(x => x.SeoTitleArabic).HasMaxLength(400);
        builder.Property(x => x.SeoDescriptionArabic).HasMaxLength(1000);
        builder.Property(x => x.SeoTitleEnglish).HasMaxLength(400);
        builder.Property(x => x.SeoDescriptionEnglish).HasMaxLength(1000);
        builder.Property(x => x.SearchNormalizedArabic).HasMaxLength(600).IsRequired();

        builder.HasMany(x => x.AudioTracks)
            .WithOne(x => x.Surah)
            .HasForeignKey(x => x.SurahId);

        builder.HasMany(x => x.Ayat)
            .WithOne(x => x.Surah)
            .HasForeignKey(x => x.SurahId);
    }
}
