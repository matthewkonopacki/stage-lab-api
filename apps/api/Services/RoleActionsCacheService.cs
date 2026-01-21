using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StageLabApi.Data;
using StageLabApi.Interfaces;

namespace StageLabApi.Services;

public class RoleActionsCacheService(IDistributedCache cache, ApplicationDbContext context)
    : IRoleActionsCacheService
{
    public async Task<List<string>> GetActionsForRoleAsync(int roleId)
    {
        var cacheKey = $"role:{roleId}:actions";

        var cachedActions = await cache.GetStringAsync(cacheKey);

        if (cachedActions != null)
        {
            return JsonSerializer.Deserialize<List<string>>(cachedActions) ?? [];
        }

        var actions = await context
            .Role.Where(r => r.Id == roleId)
            .SelectMany(r => r.Actions)
            .Select(a => a.Name)
            .ToListAsync();

        await cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(actions),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            }
        );

        return actions;
    }

    public async Task InvalidateRoleCacheAsync(int roleId)
    {
        await cache.RemoveAsync($"role:{roleId}:actions");
    }

    public async Task InvalidateAllRolesCacheAsync()
    {
        var roleIds = context.Role.Select(r => r.Id).ToListAsync();

        foreach (var roleId in roleIds.Result)
        {
            await cache.RemoveAsync($"role:{roleId}:actions");
        }
    }
}
