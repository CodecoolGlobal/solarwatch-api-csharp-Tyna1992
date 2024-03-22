using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SolarWatch.Services;
using SolarWatch.Services.Authentication;

namespace SolarUnitTests;

public class Tests
{
    [Test]
    public void GeoCoding_api_Test()
    {
        var mockLogger = new Mock<ILogger<GeoCodingApi>>();
        
        var geoCodingApi = new GeoCodingApi(mockLogger.Object);
        var city = "Berlin";
        var response = geoCodingApi.GetCoordinates(city).Result;
        Assert.NotNull(response);
        
        
        
    }
    
    [Test]
    public void JsonProcessor_Test()
    {
        var mockLog = new Mock<ILogger<GeoCodingApi>>();
        
        var geoCodingApi = new GeoCodingApi(mockLog.Object);
        var city = "Berlin";
        var geoResponse = geoCodingApi.GetCoordinates(city).Result;
        var mockLogger = new Mock<ILogger<JsonProcessor>>();
        var jsonProcessor = new JsonProcessor(mockLogger.Object);
        var response = jsonProcessor.ProcessCoordinatesJson(geoResponse);
        Assert.NotNull(response);
        Assert.That(response.Latitude, Is.EqualTo(52.517).Within(0.0001));
        Assert.That(response.Longitude, Is.EqualTo(13.3889).Within(0.0001));
    }
}