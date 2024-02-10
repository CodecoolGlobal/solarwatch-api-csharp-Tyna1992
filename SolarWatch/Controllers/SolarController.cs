using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SolarWatch.Model;
using SolarWatch.Services;


namespace SolarWatch.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SolarController : ControllerBase
{
    private readonly ILogger<SolarController> _logger;
    private readonly string _apiKey;
    private readonly IJsonProcessor _jsonProcessor;
    private readonly ISunApi _sunApi;
    private readonly IGeoCodingApi _geoCodingApi;
    
    
    
    public SolarController(ILogger<SolarController> logger, IJsonProcessor jsonProcessor, ISunApi sunApi, IGeoCodingApi geoCodingApi)
    {
        _logger = logger;
        _apiKey = "d00266d7b05eb74f62ad1714907c8af5";
        _jsonProcessor = jsonProcessor;
        _sunApi = sunApi;
        _geoCodingApi = geoCodingApi;
    }
    
   
    
    
    [HttpGet("SunriseSunset")]
    public ActionResult<SolarWatch> GetSunriseSunset([Required]string city,[Required] DateOnly date)
    {
        try
        {
            var geoCoordinatesResponse = _geoCodingApi.GetCoordinates(city);
            var geoCoordinates = _jsonProcessor.ProcessCoordinatesJson(geoCoordinatesResponse);
            
            if(geoCoordinates == null)
            {
                return NotFound("City not found");
            }
            
            var sunriseSunsetResponse = _sunApi.GetSunriseSunset(geoCoordinates, date);
            var sunriseSunset = _jsonProcessor.ProcessSunriseSunsetJson(sunriseSunsetResponse);
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

    
}