using SolarWatch.Model;

namespace SolarWatch.Services.Repositories;

public interface ISunsetSunriseRepository
{
    IEnumerable<SunriseSunset> GetAll();
    SunriseSunset? GetByName(int cityId, DateTime date);

    void Add(SunriseSunset sunriseSunset);
    void Delete(SunriseSunset sunriseSunset);
    void Update(SunriseSunset sunriseSunset);
}