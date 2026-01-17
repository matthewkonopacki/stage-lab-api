using StageLabApi.Models;
using StageLabApi.Models.QueryParams;
using StageLabApi.Models.Request;
using StageLabApi.Models.Response;

namespace StageLabApi.Interfaces;

public interface ILocationService
{
    public Task<LocationResponse?> GetLocationById(int id);
    public Task<List<LocationResponse>> QueryLocations(LocationQueryParams queryParams);
    public Task<Location> CreateLocation(CreateLocationRequest locationData);
}