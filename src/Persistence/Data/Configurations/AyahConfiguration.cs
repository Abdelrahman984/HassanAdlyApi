using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class AyahConfiguration : IEntityTypeConfiguration<Ayah>
{
    public void Configure(EntityTypeBuilder<Ayah> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => new { x.SurahId, x.AyahNumber }).IsUnique();
        builder.Property(x => x.TextUthmani).IsRequired();
        builder.Property(x => x.SajdahType).HasMaxLength(50);
    }
}
