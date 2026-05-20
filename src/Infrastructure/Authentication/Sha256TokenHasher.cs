using System.Security.Cryptography;
using System.Text;
using HassanAdly.Application.Common.Interfaces;

namespace HassanAdly.Infrastructure.Authentication;

public sealed class Sha256TokenHasher : ITokenHasher
{
    public string Hash(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(bytes);
    }
}
