namespace StageLabApi.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(
        string email,
        string userId,
        string role,
        int roleId,
        string firstName,
        string lastName
    );
}
