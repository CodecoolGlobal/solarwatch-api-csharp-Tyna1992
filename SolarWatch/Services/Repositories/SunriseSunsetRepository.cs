using SolarWatch.Data;
using SolarWatch.Model;

namespace SolarWatch.Services.Repositories;

public class SunriseSunsetRepository : ISunsetSunriseRepository
{
    private readonly GeoCoordinatesContext _dbContext;
    
    public SunriseSunsetRepository(GeoCoordinatesContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<SunriseSunset> GetAll()
    {
       
       return _dbContext.SunriseSunsets.ToList();
    }

    public SunriseSunset? GetByName(int cityId, DateTime date)
    {
       
        return _dbContext.SunriseSunsets.FirstOrDefault(ss => ss.City.Id == cityId && ss.Sunrise.Date == date);
    }

    public void Add(SunriseSunset sunriseSunset)
    {
       
        _dbContext.Add(sunriseSunset);
        _dbContext.SaveChanges();
    }

    public void Delete(SunriseSunset sunriseSunset)
    {
       
        _dbContext.Remove(sunriseSunset);
        _dbContext.SaveChanges();
    }

    public void Update(SunriseSunset sunriseSunset)
    {
     
        _dbContext.Update(sunriseSunset);
        _dbContext.SaveChanges();
    }
}