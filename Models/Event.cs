namespace StageLabApi.Models;

public class Event
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}