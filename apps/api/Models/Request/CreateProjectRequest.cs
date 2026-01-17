using Microsoft.EntityFrameworkCore;
using StageLabApi.Models.Response;

namespace StageLabApi.Models.Request;

public record CreateProjectRequest(
    ProjectType Type,
    string Name,
    string Description
    );