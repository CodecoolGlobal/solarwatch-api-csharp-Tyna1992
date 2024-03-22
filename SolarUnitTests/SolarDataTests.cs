using Microsoft.Extensions.Logging;
using Moq;
using SolarWatch;
using SolarWatch.Services;

namespace SolarUnitTests;

public class SolarDataTests
{
    [Test]
    public void SunApi_Test()
    {
        var mockLogger = new Mock<ILogger<SunApi>>();
        
        var sunApi = new SunApi(mockLogger.Object);
        var coordinates = new GeoCoordinates()
        {
            Latitude = 52.2297,
            Longitude = 21.0122
        };
        var date = new DateTime(2022, 1, 1);
        var response = sunApi.GetSunriseSunset(coordinates,date );
        Assert.NotNull(response);
    }
    
    [Test]
    public async  Task JsonProcessor_Test()
    {
        var mockLogger = new Mock<ILogger<JsonProcessor>>();
        var mockLog = new Mock<ILogger<SunApi>>();
        
        var sunApi = new SunApi(mockLog.Object);
        var coordinates = new GeoCoordinates()
        {
            Latitude = 52.2297,
            Longitude = 21.0122
        };
        var date = new DateTime(2022, 1, 1);
        var stringResponse =await sunApi.GetSunriseSunset(coordinates,date );
        
        var jsonProcessor = new JsonProcessor(mockLogger.Object);
        var response = jsonProcessor.ProcessSunriseSunsetJson(stringResponse);
        Assert.That(response, Is.Not.Null);
        Assert.NotNull(response.Sunrise);
        Assert.NotNull(response.Sunset);
    }
}