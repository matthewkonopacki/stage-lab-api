using Microsoft.AspNetCore.Mvc;
using StageLabApi.Interfaces;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService, IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        UserResponse? user = userService.GetUserByEmail(request.Email).Result;

        if (user == null || user?.Role?.Name == null)
            return Unauthorized(new { message = "Invalid credentials" });

        bool isUserValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (isUserValid)
        {
            var token = authService.GenerateJwtToken(
                request.Email,
                user.Id.ToString(),
                user.Role.Name,
                user.ActionNames
            );

            return Ok(new LoginResponse(token));
        }

        return Unauthorized(new { message = "Invalid credentials" });
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        var createdUser = await userService.CreateUser(request);

        var token = authService.GenerateJwtToken(
            request.Email,
            createdUser.UserId.ToString(),
            "Admin",
            []
        );

        return Ok(new SignUpResponse(token));
    }
}
