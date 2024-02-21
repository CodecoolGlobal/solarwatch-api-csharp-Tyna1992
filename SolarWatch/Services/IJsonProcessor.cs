using SolarWatch.Model;

namespace SolarWatch.Services;

public interface IJsonProcessor
{
    GeoCoordinates ProcessCoordinatesJson(string data);
    
    SunriseSunset ProcessSunriseSunsetJson(string data);
    public string ProcessCityJson(string data);
}