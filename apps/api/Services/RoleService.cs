using Microsoft.EntityFrameworkCore;
using StageLabApi.Data;
using StageLabApi.Interfaces;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Response;

namespace StageLabApi.Services;

public class RoleService(ApplicationDbContext context) : IRoleService
{
    public async Task<RoleResponse> GetRoleById(int id)
    {
        var query = context.Role.AsQueryable();

        return await query
            .Where(r => r.Id == id)
            .Select(r => new RoleResponse(
                r.Id,
                r.Name,
                r.Description,
                r.Actions.Select(a => new ActionResponse(a.Id, a.Name, a.Description)).ToList()
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<List<RoleResponse>> QueryRoles(RoleQueryParams queryParams)
    {
        var query = context.Role.AsQueryable();

        if (queryParams.Search != null)
        {
            query = query.Where(r => EF.Functions.ILike(r.Name, $"%{queryParams.Search}%"));
        }

        return await query
            .Select(r => new RoleResponse(
                r.Id,
                r.Name,
                r.Description,
                r.Actions.Select(a => new ActionResponse(a.Id, a.Name, a.Description)).ToList()
            ))
            .ToListAsync();
    }
}
