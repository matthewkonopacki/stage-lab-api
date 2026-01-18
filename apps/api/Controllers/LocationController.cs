using Microsoft.AspNetCore.Mvc;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;

namespace StageLabApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Location>> GetLocationById(int id)
    {
        var location = await locationService.GetLocationById(id);

        return Ok(location);
    }

    [HttpGet("query")]
    public async Task<ActionResult<Location>> QueryLocations(
        [FromQuery] LocationQueryParams queryParams
    )
    {
        var location = await locationService.QueryLocations(queryParams);

        return Ok(location);
    }

    [HttpPost()]
    public async Task<ActionResult<Location>> CreateLocation(
        [FromBody] CreateLocationRequest locationData
    )
    {
        var location = await locationService.CreateLocation(locationData);

        return Ok(location);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteLocation(int id)
    {
        var successfullyDeleted = await locationService.DeleteLocation(id);

        if (!successfullyDeleted)
            return BadRequest();

        return Ok();
    }
}
