using StageLabApi.Models.Utility;

namespace StageLabApi.Interfaces;

public interface ICurrentUserService
{
    Task<CurrentUser?> GetCurrentUserAsync();
}
