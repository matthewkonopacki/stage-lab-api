using Microsoft.AspNetCore.Mvc;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Interfaces;

public interface IEventService
{
    public Task<Event> CreateEvent(CreateEventRequest eventDto);
    public Task<List<EventResponse>> QueryEvents([FromQuery] EventQueryParams queryParams);
    public Task<Event?> GetEventById(int id);
    public Task<bool> DeleteEvent(int id);
}
