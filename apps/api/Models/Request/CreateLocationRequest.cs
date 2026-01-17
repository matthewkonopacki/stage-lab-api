namespace StageLabApi.Models.Request;

public record CreateLocationRequest(
    string Name,
    string Address1,
    string Address2,
    string City,
    string State,
    string Zip
);
