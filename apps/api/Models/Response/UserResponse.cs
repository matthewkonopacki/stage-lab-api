namespace StageLabApi.Models.Response;

public record UserResponse(
    int Id,
    string Email,
    string FirstName,
    string LastName,
    string Password,
    List<string> ActionNames,
    Role? Role
);
