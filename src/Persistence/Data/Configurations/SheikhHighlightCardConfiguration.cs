using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SheikhHighlightCardConfiguration : IEntityTypeConfiguration<SheikhHighlightCard>
{
    public void Configure(EntityTypeBuilder<SheikhHighlightCard> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.TitleArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.BodyArabic).HasMaxLength(2000);
        builder.Property(x => x.ImageUrl).HasMaxLength(2000);
    }
}
