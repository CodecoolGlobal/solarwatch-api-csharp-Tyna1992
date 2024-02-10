namespace SolarWatch.Services;

public interface ISunApi
{
    string GetSunriseSunset(GeoCoordinates coordinates, DateOnly date);
}