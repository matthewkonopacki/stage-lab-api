namespace StageLabApi.Interfaces;

public interface IRoleActionsCacheService
{
    Task<List<string>> GetActionsForRoleAsync(int roleId);
    Task InvalidateRoleCacheAsync(int roleId);
    Task InvalidateAllRolesCacheAsync();
}
