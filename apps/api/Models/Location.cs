namespace StageLabApi.Models;

public class Location
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address1 { get; set; }
    public string? Address2 { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Zip { get; set; }

    public ICollection<Event> Events { get; set; } = [];
}
