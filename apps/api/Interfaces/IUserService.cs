using StageLabApi.Models;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Interfaces;

public interface IUserService
{
    public Task<User?> GetUserByEmail(string email, string password);
    public Task<CreateUserResponse> CreateUser(SignUpRequest request);
}
