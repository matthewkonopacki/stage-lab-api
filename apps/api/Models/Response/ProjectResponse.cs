using Microsoft.EntityFrameworkCore;

namespace StageLabApi.Models.Response;

public record ProjectResponse(
    int Id,
    ProjectType Type,
    string Name,
    string Description,
    List<EventResponse>? Events = null
);
