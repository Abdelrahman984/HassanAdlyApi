using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HassanAdly.Persistence.Data;

public sealed class AppDbContextInitialiser
{
    private readonly ILogger<AppDbContextInitialiser> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IHostEnvironment _hostEnvironment;

    public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext dbContext, IHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _dbContext = dbContext;
        _hostEnvironment = hostEnvironment;
    }

    public async Task InitialiseAsync(CancellationToken cancellationToken)
    {
        try
        {
            var hasMigrations = _dbContext.Database.GetMigrations().Any();
            if (!hasMigrations)
            {
                if (_hostEnvironment.IsDevelopment())
                {
                    await _dbContext.Database.EnsureDeletedAsync(cancellationToken);
                }

                await _dbContext.Database.EnsureCreatedAsync(cancellationToken);
                return;
            }

            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        try
        {
            await TrySeedAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

        private async Task TrySeedAsync(CancellationToken cancellationToken)
    {
        // Add Featured Content
        if (!await _dbContext.FeaturedContents.AnyAsync(cancellationToken))
        {
            _dbContext.FeaturedContents.Add(new Domain.Entities.FeaturedContent
            {
                Id = 1,TitleArabic = "المحتوى المميز",
                SubtitleArabic = "اكتشف أحدث التلاوات",
                ImageUrl = "https://example.com/featured.jpg",
                LinkUrl = "/surah/1",
                DisplayOrder = 1,
                IsPublished = true
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // Add MediaAsset
        if (!await _dbContext.MediaAssets.AnyAsync(cancellationToken))
        {
            _dbContext.MediaAssets.Add(new Domain.Entities.MediaAsset
            {
                Id = 2,ObjectKey = "images/hero.jpg",
                PublicUrl = "https://example.com/hero.jpg",
                ContentType = "image/jpeg",
                SizeBytes = 512000
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}



