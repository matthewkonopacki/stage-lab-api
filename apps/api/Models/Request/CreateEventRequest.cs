namespace StageLabApi.Models.Request;

public record CreateEventRequest(
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    int LocationId,
    int? ProjectId,
    List<int> UserIds
);
