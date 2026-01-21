using StageLabApi.Interfaces;
using StageLabApi.Models.Utility;

namespace StageLabApi.Services;

public class CurrentUserService(
    IHttpContextAccessor httpContextAccessor,
    IRoleActionsCacheService roleActionsCacheService
) : ICurrentUserService
{
    public async Task<CurrentUser?> GetCurrentUserAsync()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user?.Identity?.IsAuthenticated != true)
            return null;

        var roleIdClaim = user.FindFirst("roleId")?.Value;

        if (!int.TryParse(roleIdClaim, out var roleId))
            throw new InvalidOperationException("Role Id not found");

        var currentRoleActions = await roleActionsCacheService.GetActionsForRoleAsync(roleId);

        return new CurrentUser(
            user.FindFirst("sub")?.Value ?? "",
            user.FindFirst("email")?.Value ?? "",
            roleId,
            currentRoleActions
        );
    }
}
