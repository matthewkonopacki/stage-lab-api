namespace StageLabApi.Models.Utility;

public record CurrentUser(string UserId, string Email, string Role, List<string> Actions);
