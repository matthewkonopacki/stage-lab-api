using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    [Authorize]
    [HttpGet("{roleId:int}")]
    public async Task<ActionResult<RoleResponse>> GetRole(int roleId)
    {
        var role = await roleService.GetRoleById(roleId);

        return Ok(role);
    }

    [Authorize]
    [HttpGet("query")]
    public async Task<ActionResult<List<RoleResponse>>> QueryRoles(
        [FromQuery] RoleQueryParams queryParams
    )
    {
        var roles = await roleService.QueryRoles(queryParams);

        return Ok(roles);
    }

    [Authorize]
    [HttpPost("{roleId:int}/actions")]
    public Task<ActionResult<Event>> AddRoleActions(
        int roleId,
        [FromBody] AddRoleActionsRequest request
    )
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpDelete("{roleId:int}/actions/{actionId:int}")]
    public Task<ActionResult<Event>> DeleteRoleAction(int roleId, int actionId)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpDelete("{roleId:int}/actions")]
    public Task<ActionResult<Event>> BulkDeleteRoleActions(int roleId, int actionId)
    {
        throw new NotImplementedException();
    }
}
