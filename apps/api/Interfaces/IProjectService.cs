using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Interfaces;

public interface IProjectService
{
    public Task<ProjectResponse?> GetProjectById(int id);
    public Task<List<ProjectResponse>> QueryProjects(ProjectQueryParams queryParams);
    public Task<Project> CreateProject(CreateProjectRequest projectData);
}
