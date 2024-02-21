namespace SolarWatch.Services;

public interface ISunApi
{
    Task<string> GetSunriseSunset(GeoCoordinates coordinates, DateOnly date);
}