using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SheikhExperienceConfiguration : IEntityTypeConfiguration<SheikhExperience>
{
    public void Configure(EntityTypeBuilder<SheikhExperience> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.TitleArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.DescriptionArabic).HasMaxLength(2000);
    }
}
