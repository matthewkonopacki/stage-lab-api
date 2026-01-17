using StageLabApi.Models.Utility;

namespace StageLabApi.Interfaces;

public interface ICurrentUserService
{
    CurrentUser? GetCurrentUser();
}
