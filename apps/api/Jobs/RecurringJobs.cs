using Hangfire;
using StageLabApi.Interfaces;

namespace Microsoft.EntityFrameworkCore.Jobs;

public class RecurringJobs
{
    public static void Register(IServiceProvider serviceProvider)
    {
        RecurringJob.AddOrUpdate<IFakeDataService>(
            recurringJobId: "daily-fake-data-generation",
            methodCall: service => service.GenerateFakeDataAsync(),
            cronExpression: Cron.Never,
            options: new RecurringJobOptions { TimeZone = TimeZoneInfo.Utc }
        );
    }
}
