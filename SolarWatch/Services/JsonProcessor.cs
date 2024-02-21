using System.Text.Json;
using SolarWatch.Model;

namespace SolarWatch.Services;

public class JsonProcessor : IJsonProcessor
{
    private readonly ILogger<JsonProcessor> _logger;
    
    
    public JsonProcessor(ILogger<JsonProcessor> logger)
    {
        _logger = logger;
        
    }

    public GeoCoordinates ProcessCoordinatesJson(string data)
    {
        JsonDocument json = JsonDocument.Parse(data);
        JsonElement root = json.RootElement;
        var latitude = root[0].GetProperty("lat").GetDouble();
        var longitude = root[0].GetProperty("lon").GetDouble();
        
        return new GeoCoordinates
        {
            Latitude = latitude,
            Longitude = longitude
        };

    }
    
    public string ProcessCityJson(string data)
    {
        JsonDocument json = JsonDocument.Parse(data);
        JsonElement root = json.RootElement;
        
        var country = root[0].GetProperty("country").GetString();
        
        return country;
       
    }
    
    public SunriseSunset ProcessSunriseSunsetJson(string data)
    {
        JsonDocument json = JsonDocument.Parse(data);
        JsonElement root = json.RootElement;
        var sunrise = root.GetProperty("results").GetProperty("sunrise").GetDateTime();
        var sunset = root.GetProperty("results").GetProperty("sunset").GetDateTime();
        _logger.LogInformation($"Sunrise: {sunrise}, Sunset: {sunset}");
        var sunriseSunset = new SunriseSunset
        {
            Sunrise = sunrise,
            Sunset = sunset
        };
        return sunriseSunset;
    }
}