using Microsoft.EntityFrameworkCore;
using StageLabApi.Data;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Services;

public class EventService(ApplicationDbContext context) : IEventService
{
    public async Task<Event> CreateEvent(CreateEventRequest eventData)
    {
        var eventResponse = new Event
        {
            Description = eventData.Description,
            EndDateTime = eventData.EndDateTime,
            LocationId = eventData.LocationId,
            ProjectId = eventData.ProjectId,
            StartDateTime = eventData.StartDateTime,
            EventUsers = eventData
                .UserIds.Select(userId => new EventUser { UserId = userId })
                .ToList(),
        };

        context.Event.Add(eventResponse);

        await context.SaveChangesAsync();

        return eventResponse;
    }

    public async Task<Event?> GetEventById(int id)
    {
        return await context.Event.FindAsync(id);
    }

    public async Task<List<EventResponse>> QueryEvents(EventQueryParams queryParams)
    {
        var query = context.Event.AsQueryable();

        if (queryParams.UserId != null)
        {
            query = query.Where(e => e.EventUsers.Any(eu => eu.UserId == queryParams.UserId));
        }
        var events = await query
            .Select(e => new EventResponse(
                e.Id,
                e.Description,
                e.StartDateTime,
                e.EndDateTime,
                e.Location != null
                    ? new EventLocationResponse(
                        e.Location.Id,
                        e.Location.Name,
                        e.Location.Address1,
                        e.Location.Address2,
                        e.Location.City,
                        e.Location.State,
                        e.Location.Zip
                    )
                    : null
            ))
            .ToListAsync();

        return events;
    }

    public async Task<bool> DeleteEvent(int id)
    {
        var deletedEvent = await context.Event.Where(e => e.Id == id).ExecuteDeleteAsync();

        if (deletedEvent == 0)
            return false;

        return true;
    }
}
