using Microsoft.EntityFrameworkCore;

namespace StageLabApi.Models;

public class Project
{
    public int Id { get; set; }
    public ProjectType Type { get; set; } = ProjectType.Production;
    public required string Name { get; set; }
    public required string Description { get; set; }

    public ICollection<Event> Events { get; set; } = [];
}
