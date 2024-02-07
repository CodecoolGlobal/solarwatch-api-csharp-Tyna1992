using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SolarWatch.Model;


namespace SolarWatch.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SolarController : ControllerBase
{
    private readonly ILogger<SolarController> _logger;
    private readonly string _apiKey;
    
    
    public SolarController(ILogger<SolarController> logger)
    {
        _logger = logger;
        _apiKey = "d00266d7b05eb74f62ad1714907c8af5";
    }

    
    
    
    [HttpGet("SunriseSunset")]
    public ActionResult<SolarWatch> GetSunriseSunset([Required]string city,[Required] DateOnly date)
    {
        try
        {
            var geoCoordinates = GetGeoCoordinates(city);
            if(geoCoordinates == null)
            {
                return NotFound("City not found");
            }
            
            var sunriseSunset = GetSunriseSunset(geoCoordinates, date);
            var solarWatch = new SolarWatch
            {
                Date = date,
                City = city,
                Sunrise = sunriseSunset.Sunrise,
                Sunset = sunriseSunset.Sunset
            };
            return Ok(solarWatch);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"An error occurred: {e.Message}");
        }
    }

    private GeoCoordinates GetGeoCoordinates(string city)
    {
        var url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit={1}&appid={_apiKey}";
        try
        {
            using var client = new WebClient();
            var response = client.DownloadString(url);
            _logger.LogInformation($"Received data from API: {response}");
            if(response == "[]")
            {
                return null;
            }
            var json = JsonDocument.Parse(response);
            var root = json.RootElement;
            var latitude = root[0].GetProperty("lat").GetDouble();
            var longitude = root[0].GetProperty("lon").GetDouble();
            
            return new GeoCoordinates
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }
        catch (WebException e)
        {
            _logger.LogError($"An error occurred while fetching data from API: {e.Message}");
            return null;
        }
    }


    private SunriseSunset GetSunriseSunset(GeoCoordinates coordinates, DateOnly date)
    {
        var url = $"https://api.sunrise-sunset.org/json?lat={coordinates.Latitude}&lng={coordinates.Longitude}&date={date.Year}-{date.Month}-{date.Day}&formatted=0&date={date.Year}-{date.Month}-{date.Day}";
        var client = new WebClient();
        var response = client.DownloadString(url);
        var json = JsonDocument.Parse(response);
        var root = json.RootElement;
        var sunrise = root.GetProperty("results").GetProperty("sunrise").GetDateTime();
        var sunset = root.GetProperty("results").GetProperty("sunset").GetDateTime();
        _logger.LogInformation($"Sunrise: {sunrise}, Sunset: {sunset}");
        var sunriseSunset = new SunriseSunset
        {
            Sunrise = TimeOnly.FromDateTime(sunrise),
            Sunset = TimeOnly.FromDateTime(sunset)
        };
        return sunriseSunset;
    }
}