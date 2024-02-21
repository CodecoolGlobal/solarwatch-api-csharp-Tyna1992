namespace SolarWatch.Model;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public GeoCoordinates Coordinates { get; set; }
    public string Country { get; set; }
    public SunriseSunset SunriseSunset { get; set; }
    public int SunriseSunsetId { get; set; }
}