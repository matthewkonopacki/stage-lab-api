using Microsoft.EntityFrameworkCore;
using StageLabApi.Data;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Services;

public class UserService(ApplicationDbContext context) : IUserService
{
    public async Task<UserResponse?> GetUserByEmail(string email)
    {
        var query = context.User.AsQueryable();

        UserResponse? userResponse = await query
            .Where(u => u.Email == email)
            .Select(u => new UserResponse(
                u.Id,
                u.Email,
                u.FirstName,
                u.LastName,
                u.Password,
                u.Role!.Actions.Select(a => a.Name).ToList(),
                u.Role
            ))
            .FirstOrDefaultAsync();

        return userResponse;
    }

    public async Task<CreateUserResponse> CreateUser(SignUpRequest userData)
    {
        User user = new User
        {
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
            Password = BCrypt.Net.BCrypt.HashPassword(userData.Password),
            RoleId = userData.RoleId,
        };

        context.User.Add(user);
        await context.SaveChangesAsync();

        return new CreateUserResponse(user.Email, user.Id);
    }
}
