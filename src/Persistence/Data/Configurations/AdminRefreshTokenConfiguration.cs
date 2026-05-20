using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class AdminRefreshTokenConfiguration : IEntityTypeConfiguration<AdminRefreshToken>
{
    public void Configure(EntityTypeBuilder<AdminRefreshToken> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.TokenHash).HasMaxLength(200).IsRequired();
        builder.HasIndex(x => x.TokenHash).IsUnique();
    }
}
