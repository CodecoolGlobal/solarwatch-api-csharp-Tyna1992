using System.Net;
using SolarWatch.Model;

namespace SolarWatch.Services;

public class SunApi : ISunApi
{
    private readonly ILogger<SunApi> _logger;
    
    
    public SunApi(ILogger<SunApi> logger)
    {
        _logger = logger;
    }
    
    public async Task<string> GetSunriseSunset(GeoCoordinates coordinates, DateTime date)
    {
        var url = $"https://api.sunrise-sunset.org/json?lat={coordinates.Latitude}&lng={coordinates.Longitude}&date={date.Year}-{date.Month}-{date.Day}&formatted=0&date={date.Year}-{date.Month}-{date.Day}";
        var client = new HttpClient();
        var response = await client.GetAsync(url);

        return await  response.Content.ReadAsStringAsync();
    }
}