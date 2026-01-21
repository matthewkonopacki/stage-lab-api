using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(
    ILogger<EventController> logger,
    IEventService eventService,
    ICurrentUserService currentUserService
) : ControllerBase
{
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Event>> GetEventById(int id)
    {
        var user = await currentUserService.GetCurrentUserAsync();

        logger.LogInformation(JsonSerializer.Serialize(user));
        logger.LogInformation("Current User Actions: {Actions}", user?.Actions);
        var eventItem = await eventService.GetEventById(id);

        if (eventItem == null)
            return NotFound();

        return eventItem;
    }

    [Authorize]
    [HttpGet("query")]
    public async Task<ActionResult<List<EventResponse>>> QueryEvents(
        [FromQuery] EventQueryParams queryParams
    )
    {
        var events = await eventService.QueryEvents(queryParams);

        return Ok(events);
    }

    [Authorize]
    [HttpPost()]
    public async Task<ActionResult<Event>> Post([FromBody] CreateEventRequest eventData)
    {
        var eventRecord = await eventService.CreateEvent(eventData);

        return CreatedAtAction(nameof(GetEventById), new { id = eventRecord.Id }, eventData);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var successfullyDeleted = await eventService.DeleteEvent(id);

        if (!successfullyDeleted)
            return BadRequest();

        return Ok();
    }
}
