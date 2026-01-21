namespace StageLabApi.Models.Response;

public record RoleResponse(int Id, string Name, string Description, List<ActionResponse> Actions);
