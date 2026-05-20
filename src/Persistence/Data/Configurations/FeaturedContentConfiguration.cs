using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class FeaturedContentConfiguration : IEntityTypeConfiguration<FeaturedContent>
{
    public void Configure(EntityTypeBuilder<FeaturedContent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.TitleArabic).HasMaxLength(600).IsRequired();
        builder.Property(x => x.SubtitleArabic).HasMaxLength(600);
        builder.Property(x => x.ImageUrl).HasMaxLength(2000);
        builder.Property(x => x.LinkUrl).HasMaxLength(2000);
    }
}
