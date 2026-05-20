using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SheikhEducationConfiguration : IEntityTypeConfiguration<SheikhEducation>
{
    public void Configure(EntityTypeBuilder<SheikhEducation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.TitleArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.InstitutionArabic).HasMaxLength(400);
        builder.Property(x => x.DescriptionArabic).HasMaxLength(2000);
    }
}
