using Microsoft.EntityFrameworkCore;
using StageLabApi.Data;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Services;

public class ProjectService(ApplicationDbContext context) : IProjectService
{
    public async Task<ProjectResponse?> GetProjectById(int id)
    {
        var project = await context.Project.FindAsync(id);

        if (project == null)
            return null;

        return new ProjectResponse(project.Id, project.Type, project.Name, project.Description);
    }

    public async Task<List<ProjectResponse>> QueryProjects(ProjectQueryParams queryParams)
    {
        var query = context.Project.AsQueryable();

        if (queryParams.Search != null)
        {
            query = query.Where(p => p.Name.Contains(queryParams.Search));
        }

        var projects = await query
            .Select(p => new ProjectResponse(p.Id, p.Type, p.Name, p.Description))
            .ToListAsync();

        return projects;
    }

    public async Task<Project> CreateProject(CreateProjectRequest projectData)
    {
        Project projectResponse = new Project
        {
            Type = projectData.Type,
            Name = projectData.Name,
            Description = projectData.Description,
        };

        context.Project.Add(projectResponse);

        await context.SaveChangesAsync();

        return projectResponse;
    }

    public async Task<bool> DeleteProject(int id)
    {
        var successfullyDeleted = await context.Project.Where(e => e.Id == id).ExecuteDeleteAsync();

        if (successfullyDeleted == 0)
            return false;

        return true;
    }
}
