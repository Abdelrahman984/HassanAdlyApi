using System.Security.Cryptography;
using HassanAdly.Application.Common.Interfaces;

namespace HassanAdly.Infrastructure.Authentication;

public sealed class SecureRefreshTokenGenerator : IRefreshTokenGenerator
{
    public string Generate()
    {
        Span<byte> bytes = stackalloc byte[32];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToBase64String(bytes);
    }
}
