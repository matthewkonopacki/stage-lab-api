namespace StageLabApi.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(string email, string userId);
}
