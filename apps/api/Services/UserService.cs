using Microsoft.EntityFrameworkCore;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Services;

public class UserService(ApplicationDbContext context) : IUserService
{
    public Task<User?> GetUserByEmail(string email, string password)
    {
        return context.User.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<CreateUserResponse> CreateUser(SignUpRequest userData)
    {
        User user = new User
        {
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName,
            Password = BCrypt.Net.BCrypt.HashPassword(userData.Password),
        };

        context.User.Add(user);
        await context.SaveChangesAsync();

        return new CreateUserResponse(user.Email, user.Id);
    }
}
