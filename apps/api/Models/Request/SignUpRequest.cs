namespace StageLabApi.Models.Request;

public record SignUpRequest(string Email, string Password, string FirstName, string LastName);
