using Microsoft.EntityFrameworkCore;
using StageLabApi.Interfaces;
using StageLabApi.Models;

namespace StageLabApi.Services;

public class UserService(ApplicationDbContext context) : IUserService
{
    public Task<User?> GetUserByEmail(string email, string password)
    {
        return context.User.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<User> CreateUser(User userData)
    {
        userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);

        context.User.Add(userData);
        await context.SaveChangesAsync();
        
        return userData;
    }
}