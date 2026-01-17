using Microsoft.AspNetCore.Mvc;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Project>> GetProjectById(int id)
    {
        var project = await projectService.GetProjectById(id);
        
        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpGet("query")]
    public async Task<ActionResult<ProjectResponse>> QueryProjects(
        [FromQuery] ProjectQueryParams queryParams
    )
    {
        var projects = await projectService.QueryProjects(queryParams);

        return Ok(projects);
    }

    [HttpPost()]
    public async Task<ActionResult<Project>> CreateProject(
        [FromBody] CreateProjectRequest projectData
    )
    {
        var project = await projectService.CreateProject(projectData);

        return Ok(project);
    }
}