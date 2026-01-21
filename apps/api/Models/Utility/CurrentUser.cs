namespace StageLabApi.Models.Utility;

public record CurrentUser(string UserId, string Email, int RoleId, List<string> Actions);
