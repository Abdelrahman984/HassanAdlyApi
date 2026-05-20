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
}
