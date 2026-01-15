using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageLabApi.Models;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(ApplicationDbContext context) : ControllerBase
{
    [Authorize]
    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(new Event());
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var eventItem = await context.Event.FindAsync(id);
        
        if (eventItem == null)
            return NotFound();
            
        return eventItem;
    }
    
    [Authorize]
    [HttpPost()]
    public async Task<ActionResult<Event>> Post([FromBody] Event eventData)
    {
        context.Event.Add(eventData);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetEvent), new {id = eventData.Id }, eventData);
    }
}
