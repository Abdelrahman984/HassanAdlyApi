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
        builder.Property(x => x.HeroImageUrl).HasMaxLength(2000);
        builder.Property(x => x.HeroTitleArabic).HasMaxLength(400);
        builder.Property(x => x.HeroSubtitleArabic).HasMaxLength(1000);

        builder.HasMany(x => x.AudioTracks)
            .WithOne(x => x.Sheikh)
            .HasForeignKey(x => x.SheikhId);

        builder.HasMany(x => x.EducationEntries)
            .WithOne(x => x.Sheikh)
            .HasForeignKey(x => x.SheikhId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.ExperienceEntries)
            .WithOne(x => x.Sheikh)
            .HasForeignKey(x => x.SheikhId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Teachers)
            .WithOne(x => x.Sheikh)
            .HasForeignKey(x => x.SheikhId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.HighlightCards)
            .WithOne(x => x.Sheikh)
            .HasForeignKey(x => x.SheikhId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
    new Sheikh
    {
        Id = 1,
        Slug = "hassan-adly",
        DisplayNameArabic = "حسن عدلي",
        DisplayNameEnglish = "Hassan Adly",
        FullNameArabic = "حسن بن محمد مصطفى عدلي",
        BirthDate = new System.DateOnly(1980, 1, 1),
        BirthPlaceArabic = "مصر",
        BiographyArabic = "قارئ القرآن الكريم",
        ShortDescriptionArabic = "قارئ ومقرئ للقرآن الكريم",
        ProfileImageUrl = "/images/hassan-adly-profile.jpg",
        HeroImageUrl = "/images/hero-bg.jpg",
        HeroTitleArabic = "الشيخ حسن عدلي",
        HeroSubtitleArabic = "المقرئ بالقراءات العشر",
        IsActive = true
    }
);

    }
}

