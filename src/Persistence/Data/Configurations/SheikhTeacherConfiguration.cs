using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SheikhTeacherConfiguration : IEntityTypeConfiguration<SheikhTeacher>
{
    public void Configure(EntityTypeBuilder<SheikhTeacher> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.NameArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.DescriptionArabic).HasMaxLength(2000);
    }
}
