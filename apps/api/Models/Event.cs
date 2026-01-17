namespace StageLabApi.Models;

public class Event
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int LocationId { get; set; }
    public int? ProjectId { get; set; }

    public ICollection<EventUser> EventUsers { get; set; } = [];
    public Location? Location { get; set; }
    public Project? Project { get; set; }
}
