using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Response;

namespace StageLabApi.Interfaces;

public interface IRoleService
{
    public Task<RoleResponse> GetRoleById(int id);
    public Task<List<RoleResponse>> QueryRoles(RoleQueryParams queryParams);
}
