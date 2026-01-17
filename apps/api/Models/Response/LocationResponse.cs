namespace StageLabApi.Models.Response;

public record LocationResponse(
    int Id,
    string Name,
    string Address1,
    string? Address2,
    string City,
    string State,
    string Zip
);
