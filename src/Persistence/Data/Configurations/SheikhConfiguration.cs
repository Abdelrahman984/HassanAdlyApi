using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SheikhConfiguration : IEntityTypeConfiguration<Sheikh>
{
    public void Configure(EntityTypeBuilder<Sheikh> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
        builder.HasIndex(x => x.Slug).IsUnique();

        builder.Property(x => x.DisplayNameArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.DisplayNameEnglish).HasMaxLength(400);
        builder.Property(x => x.FullNameArabic).HasMaxLength(800).IsRequired();
        builder.Property(x => x.BirthPlaceArabic).HasMaxLength(400);
        builder.Property(x => x.ShortDescriptionArabic).HasMaxLength(500).IsRequired();
        builder.Property(x => x.ProfileImageUrl).HasMaxLength(2000).IsRequired();

        builder.HasMany(x => x.AudioTracks)
            .WithOne(x => x.Sheikh)
            .HasForeignKey(x => x.SheikhId);
    }
}
