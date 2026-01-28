using Hangfire.Dashboard;

namespace StageLabApi.Infrastructure;

public class AllowAllDashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}
