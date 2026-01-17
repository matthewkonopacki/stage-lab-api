using StageLabApi.Models;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Interfaces;

public interface IUserService
{
    public Task<UserResponse?> GetUserByEmail(string email);
    public Task<CreateUserResponse> CreateUser(SignUpRequest request);
}
