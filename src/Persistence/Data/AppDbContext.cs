using System.Reflection;
using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Sheikh> Sheikhs => Set<Sheikh>();
    public DbSet<Surah> Surahs => Set<Surah>();
    public DbSet<Ayah> Ayat => Set<Ayah>();
    public DbSet<Qiraa> Qiraat => Set<Qiraa>();
    public DbSet<AudioTrack> AudioTracks => Set<AudioTrack>();
    public DbSet<AyahTiming> AyahTimings => Set<AyahTiming>();
    public DbSet<MediaAsset> MediaAssets => Set<MediaAsset>();
    public DbSet<FeaturedContent> FeaturedContents => Set<FeaturedContent>();
    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();
    public DbSet<AdminRefreshToken> AdminRefreshTokens => Set<AdminRefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
