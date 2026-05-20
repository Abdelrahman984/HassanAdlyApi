using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(AdminUser adminUser, string password);
}
