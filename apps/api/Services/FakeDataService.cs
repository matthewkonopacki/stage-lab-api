using Bogus;
using Microsoft.EntityFrameworkCore;
using StageLabApi.Data;
using StageLabApi.Data.SeedData;
using StageLabApi.Interfaces;
using StageLabApi.Models;

namespace StageLabApi.Services;

public class FakeDataService(ILogger<FakeDataService> logger, ApplicationDbContext context)
    : IFakeDataService
{
    private static readonly (string Type, int DayOffset)[] ProductionTimeline =
    [
        ("Load-in", 0),
        ("Rehearsal", 1),
        ("Rehearsal", 2),
        ("Rehearsal", 3),
        ("Rehearsal", 5),
        ("Rehearsal", 6),
        ("Rehearsal", 7),
        ("Rehearsal", 8),
        ("Tech Run", 10),
        ("Tech Run", 11),
        ("Dress Rehearsal", 12),
        ("Dress Rehearsal", 13),
        ("Performance", 14),
        ("Performance", 15),
        ("Performance", 16),
        ("Strike", 17),
    ];

    public async Task GenerateFakeDataAsync()
    {
        try
        {
            var locationIds = await context.Location.Select(l => l.Id).ToListAsync();
            var userIds = await context.User.Select(u => u.Id).ToListAsync();

            var projects = GenerateFakeProjects(10, locationIds, userIds);
            await context.AddRangeAsync(projects);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error generating fake data");
        }
    }

    private List<Project> GenerateFakeProjects(int count, List<int> locationIds, List<int> userIds)
    {
        var eventTypes = new[]
        {
            "Rehearsal",
            "Tech Run",
            "Dress Rehearsal",
            "Performance",
            "Load-in",
            "Strike",
        };

        var faker = new Faker<Project>().CustomInstantiator(f =>
        {
            var opera = f.Opera().Full();

            var project = new Project
            {
                Name = opera.Title,
                Description = $"A production of {opera.Title} by {opera.Composer}",
            };

            var productionStart = f.Date.Future(1).ToUniversalTime();

            var selectedEvents = ProductionTimeline.Where(_ => f.Random.Bool(0.6f)).ToList();

            if (selectedEvents.Count < 2)
            {
                selectedEvents = [ProductionTimeline[0], ProductionTimeline[^1]];
            }

            project.Events = selectedEvents
                .Select(evt =>
                {
                    var eventEntity = new Event
                    {
                        Description = $"{evt.Type} - {opera.Title}",
                        StartDateTime = productionStart.AddDays(evt.DayOffset),
                        EndDateTime = productionStart
                            .AddDays(evt.DayOffset)
                            .AddHours(f.Random.Int(2, 6)),
                        LocationId = f.PickRandom(locationIds),
                    };

                    var assignedUserIds = f.PickRandom(userIds, f.Random.Int(1, 4)).Distinct();

                    eventEntity.EventUsers = assignedUserIds
                        .Select(userId => new EventUser { UserId = userId })
                        .ToList();

                    return eventEntity;
                })
                .ToList();

            return project;
        });

        return faker.Generate(count);
    }
}
