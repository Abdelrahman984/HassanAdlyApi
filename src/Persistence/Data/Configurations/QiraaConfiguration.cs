using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class QiraaConfiguration : IEntityTypeConfiguration<Qiraa>
{
    public void Configure(EntityTypeBuilder<Qiraa> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
        builder.HasIndex(x => x.Slug).IsUnique();

        builder.Property(x => x.NameArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.NameEnglish).HasMaxLength(200);
        builder.Property(x => x.RawiArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.ImamArabic).HasMaxLength(400);
        builder.Property(x => x.DescriptionArabic).HasMaxLength(1000);

        builder.HasMany(x => x.AudioTracks)
            .WithOne(x => x.Qiraa)
            .HasForeignKey(x => x.QiraaId);
    }
}
