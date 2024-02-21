namespace SolarWatch.Services;

public interface IGeoCodingApi
{
    Task<string> GetCoordinates(string city);
}