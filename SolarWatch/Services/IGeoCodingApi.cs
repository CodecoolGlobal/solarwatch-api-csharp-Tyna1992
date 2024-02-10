namespace SolarWatch.Services;

public interface IGeoCodingApi
{
    string GetCoordinates(string city);
}