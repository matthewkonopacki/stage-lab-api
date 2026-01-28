using System.ComponentModel.DataAnnotations;

namespace StageLabApi.Models.Request;

public record SignUpRequest(
    [Required, EmailAddress, MaxLength(255)] string Email,
    [Required, MinLength(8), MaxLength(255)] string Password,
    [Required, MaxLength(50)] string FirstName,
    [Required, MaxLength(50)] string LastName,
    [Required] int RoleId
);
