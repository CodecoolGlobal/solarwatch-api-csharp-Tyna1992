namespace SolarWatch.Model;

public class SunriseSunset
{
    public int Id { get; set; }
    public DateTime Sunrise { get; set; }
    public DateTime Sunset { get; set; }
    public City City { get; set; }
    
}