using HassanAdly.Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace HassanAdly.Infrastructure.Media;

public sealed class CdnMediaUrlResolver : IMediaUrlResolver
{
    private readonly MediaOptions _options;

    public CdnMediaUrlResolver(IOptions<MediaOptions> options)
    {
        _options = options.Value;
    }

    public string ResolvePublicUrl(string objectKey)
    {
        if (string.IsNullOrWhiteSpace(objectKey))
        {
            return string.Empty;
        }

        if (Uri.TryCreate(objectKey, UriKind.Absolute, out var absolute))
        {
            return absolute.ToString();
        }

        var baseUrl = _options.CdnBaseUrl?.TrimEnd('/') ?? string.Empty;
        var key = objectKey.TrimStart('/');
        return string.IsNullOrWhiteSpace(baseUrl) ? "/" + key : $"{baseUrl}/{key}";
    }
}
