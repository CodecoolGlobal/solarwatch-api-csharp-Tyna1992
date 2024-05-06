using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarWatch.Model;
using SolarWatch.Services;
using SolarWatch.Services.Repositories;


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
    private readonly ICityRepository _cityRepository;
    private readonly ISunsetSunriseRepository _sunsetSunriseRepository;


    public SolarController(ILogger<SolarController> logger, IJsonProcessor jsonProcessor,
        ISunApi sunApi, IGeoCodingApi geoCodingApi, ICityRepository cityRepository,
        ISunsetSunriseRepository sunsetSunriseRepository)
    {
        _logger = logger;
        _apiKey = "d00266d7b05eb74f62ad1714907c8af5";
        _jsonProcessor = jsonProcessor;
        _sunApi = sunApi;
        _geoCodingApi = geoCodingApi;
        _cityRepository = cityRepository;
        _sunsetSunriseRepository = sunsetSunriseRepository;
    }


    [HttpGet("SunriseSunset/{city}/{date}")]
    public async Task<ActionResult<SolarWatch>> GetSunriseSunset([Required] string city, [Required] DateTime date)
    {
        var existingCity = _cityRepository.GetByName(city);

        if (existingCity == null)
        {

            var geoCoordinatesResponse = await _geoCodingApi.GetCoordinates(city);
            var geoCoordinates = _jsonProcessor.ProcessCoordinatesJson(geoCoordinatesResponse);
            var locationInfo = _jsonProcessor.ProcessCityJson(geoCoordinatesResponse);

            _logger.LogInformation(geoCoordinatesResponse);
            Console.WriteLine(geoCoordinatesResponse);
            if (geoCoordinates != null)
            {
                existingCity = new City()
                {
                    Name = city,
                    Coordinates = geoCoordinates,
                    Country = locationInfo

                };
            }
            else
            {
                return NotFound($"City {city} not found.");
            }
        }

        var exisingSunriseSunset = _sunsetSunriseRepository.GetByName(existingCity.Id, date);
        if (exisingSunriseSunset == null)
        {
            var sunriseSunsetResponse = await _sunApi.GetSunriseSunset(existingCity.Coordinates, date);
            var sunriseSunset = _jsonProcessor.ProcessSunriseSunsetJson(sunriseSunsetResponse);

            if (sunriseSunset != null)
            {
                exisingSunriseSunset = new SunriseSunset
                { City = existingCity, Sunrise = sunriseSunset.Sunrise, Sunset = sunriseSunset.Sunset };
                _sunsetSunriseRepository.Add(exisingSunriseSunset);
            }
            else
            {
                return NotFound($"Sunrise and sunset for {city} on {date} not found.");
            }
        }


        var solarWatch = new SolarWatch
        {
            Date = date,
            City = city,
            Sunrise = exisingSunriseSunset.Sunrise,
            Sunset = exisingSunriseSunset.Sunset
        };
        return Ok(solarWatch);
    }

    [HttpGet("SunriseSunset/all"), Authorize(Roles = "Admin")]
    public ActionResult<List<SolarWatch>> GetAllSolarData()
    {
        var allData = new List<SolarWatch>();
        var allCities = _cityRepository.GetAll();
        foreach(var city in allCities){
            var existingSunriseSunset = _sunsetSunriseRepository.GetById(city.Id);
            if(existingSunriseSunset != null){
                var solarWatch = new SolarWatch
                {
                    Date = existingSunriseSunset.Sunset.Date,
                    City = city.Name,
                    Sunrise = existingSunriseSunset.Sunrise,
                    Sunset = existingSunriseSunset.Sunset
                };
                allData.Add(solarWatch);
            }
        }
        return Ok(allData);
                

    }
}