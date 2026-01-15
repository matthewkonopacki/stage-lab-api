using StageLabApi.Models;

namespace StageLabApi.Interfaces;

public interface IUserService
{
    public Task<User?> GetUserByEmail(string email, string password);
    public Task<User> CreateUser(User userData);
}