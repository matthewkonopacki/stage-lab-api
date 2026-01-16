namespace StageLabApi.Models.Response;

public record EventResponse(
    int Id,
    string? Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    EventLocationResponse Location
);
