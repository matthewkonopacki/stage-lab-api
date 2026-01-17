using StageLabApi.Interfaces;
using StageLabApi.Models.Utility;

namespace StageLabApi.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user?.Identity?.IsAuthenticated != true)
            return null;

        return new CurrentUser(
            user.FindFirst("sub")?.Value ?? "",
            user.FindFirst("email")?.Value ?? "",
            user.FindFirst("role")?.Value ?? "",
            user.FindAll("action")?.Select(c => c.Value).ToList() ?? new List<string>()
        );
    }
}
