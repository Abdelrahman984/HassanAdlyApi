using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Auth.Queries.AdminMe;

public sealed record AdminMeQuery(long AdminUserId) : IRequest<AdminMeDto?>;

public sealed class AdminMeQueryHandler : IRequestHandler<AdminMeQuery, AdminMeDto?>
{
    private readonly IAdminUserRepository _adminUserRepository;

    public AdminMeQueryHandler(IAdminUserRepository adminUserRepository)
    {
        _adminUserRepository = adminUserRepository;
    }

    public async Task<AdminMeDto?> Handle(AdminMeQuery request, CancellationToken cancellationToken)
    {
        var adminUser = await _adminUserRepository.GetByIdAsync(request.AdminUserId, cancellationToken);
        if (adminUser is null)
        {
            return null;
        }

        return new AdminMeDto(
            adminUser.Id,
            adminUser.Email,
            adminUser.DisplayName,
            adminUser.Role,
            adminUser.IsActive);
    }
}
