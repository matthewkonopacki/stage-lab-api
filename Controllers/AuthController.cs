using Microsoft.AspNetCore.Mvc;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.Request;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService, IUserService userService, ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        User? user = userService.GetUserByEmail(request.Email, request.Password).Result;
        
        if (user == null) 
            return Unauthorized(new { message = "Invalid credentials" });
        
        bool isUserValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        
        if (isUserValid)
        {
            var token = authService.GenerateJwtToken(request.Email, user.Id.ToString());
            return Ok(new {token});
        }

        return Unauthorized(new { message = "Invalid credentials" });
    }
    
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] User request)
    {
        var createdUser = await userService.CreateUser(request);
        
        var token = authService.GenerateJwtToken(request.Email, createdUser.Id.ToString());
        return Ok(new {token});
    }
    
}