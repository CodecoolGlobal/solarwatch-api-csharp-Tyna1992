using System.Net;

namespace SolarWatch.Services;

public class GeoCodingApi : IGeoCodingApi
{
    private readonly ILogger<GeoCodingApi> _logger;
    private readonly string _apiKey;
    
    public GeoCodingApi(ILogger<GeoCodingApi> logger)
    {
        _logger = logger;
        _apiKey = "d00266d7b05eb74f62ad1714907c8af5";
    }

    public string GetCoordinates(string city)
    {
        var url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit={1}&appid={_apiKey}";
        
            using var client = new WebClient();
            var response = client.DownloadString(url);
            _logger.LogInformation($"Received data from API: {response}");
            if(response == "[]")
            {
                return null;
            }

            return response;
    }
}