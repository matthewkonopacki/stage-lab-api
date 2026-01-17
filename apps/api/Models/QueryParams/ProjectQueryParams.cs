namespace StageLabApi.Models.QueryParams;

public record ProjectQueryParams(
    string? Search,
    int? PageNumber,
    int? PageSize
    );