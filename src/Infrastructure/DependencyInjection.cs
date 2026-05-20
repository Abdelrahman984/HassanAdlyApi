using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Infrastructure.Authentication;
using HassanAdly.Infrastructure.Media;
using HassanAdly.Infrastructure.Uploads;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton(TimeProvider.System);

        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
        builder.Services.Configure<MediaOptions>(builder.Configuration.GetSection("Media"));

        builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();
        builder.Services.AddSingleton<ITokenHasher, Sha256TokenHasher>();
        builder.Services.AddSingleton<IRefreshTokenGenerator, SecureRefreshTokenGenerator>();
        builder.Services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
        builder.Services.AddSingleton<IMediaUrlResolver, CdnMediaUrlResolver>();
        builder.Services.AddSingleton<IUploadFlowService, PlaceholderUploadFlowService>();
    }
}
