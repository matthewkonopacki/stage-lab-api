using Microsoft.EntityFrameworkCore;
using StageLabApi.Interfaces;
using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Services;

public class LocationService(ApplicationDbContext context) : ILocationService
{
    public async Task<LocationResponse?> GetLocationById(int id)
    {
        var location = await context.Location.FindAsync(id);
        
        if (location == null)
            return null;

        return new LocationResponse(
            location.Id,
            location.Name,
            location.Address1,
            location.Address2,
            location.City,
            location.State,
            location.Zip
        );
    }

    public async Task<List<LocationResponse>> QueryLocations(LocationQueryParams queryParams)
    {
        var query = context.Location.AsQueryable();

        var locations = await query.Select(l => new LocationResponse(
            l.Id,
            l.Name,
            l.Address1,
            l.Address2,
            l.City,
            l.State,
            l.Zip
        )).ToListAsync();
        
        return locations;
    }
    
    public async Task<Location> CreateLocation(CreateLocationRequest locationData)
    {
        Location locationResponse = new Location
        {
            Address1 = locationData.Address1,
            Address2 = locationData.Address2,
            City = locationData.City,
            State = locationData.State,
            Zip = locationData.Zip,
            Name = locationData.Name
        };

        context.Location.Add(locationResponse);

        await context.SaveChangesAsync();

        return locationResponse;
    }
}