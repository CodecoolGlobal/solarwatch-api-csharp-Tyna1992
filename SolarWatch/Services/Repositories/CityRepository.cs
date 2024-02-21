using SolarWatch.Data;
using SolarWatch.Model;

namespace SolarWatch.Services.Repositories;

public class CityRepository : ICityRepository
{
    private readonly GeoCoordinatesContext _dbContext;
    
    public CityRepository(GeoCoordinatesContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<City> GetAll()
    {
        
        return _dbContext.Cities.ToList();
    }

    public City? GetByName(string name)
    {
       
        return _dbContext.Cities.FirstOrDefault(c => c.Name == name);
    }

    public void Add(City city)
    {
        
        _dbContext.Add(city);
        _dbContext.SaveChanges();
    }

    public void Delete(City city)
    {
        
        _dbContext.Remove(city);
        _dbContext.SaveChanges();
    }

    public void Update(City city)
    {
       
        _dbContext.Update(city);
        _dbContext.SaveChanges();
    }
}