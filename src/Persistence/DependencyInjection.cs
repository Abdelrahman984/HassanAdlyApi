using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Application.Admin.Dashboard.Queries.GetAdminDashboard;
using HassanAdly.Persistence.Data;
using HassanAdly.Persistence.Data.Interceptors;
using HassanAdly.Persistence.QueryServices;
using HassanAdly.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddPersistenceServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'Database' not found.");
        }

        builder.Services.AddSingleton(TimeProvider.System);
        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        builder.Services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<ISheikhRepository, SheikhRepository>();
        builder.Services.AddScoped<ISurahRepository, SurahRepository>();
        builder.Services.AddScoped<IQiraaRepository, QiraaRepository>();
        builder.Services.AddScoped<IFeaturedContentRepository, FeaturedContentRepository>();
        builder.Services.AddScoped<IAudioTrackRepository, AudioTrackRepository>();
        builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
        builder.Services.AddScoped<IAdminRefreshTokenRepository, AdminRefreshTokenRepository>();
        builder.Services.AddScoped<IAdminDashboardQueryService, AdminDashboardQueryService>();
        builder.Services.AddScoped<IRecordingMatrixQueryService, RecordingMatrixQueryService>();

        builder.Services.AddScoped<AppDbContextInitialiser>();
    }
}
