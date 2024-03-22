using System.Net;

namespace SolarWatch.Services;

public class GeoCodingApi : IGeoCodingApi
{
    private readonly ILogger<GeoCodingApi> _logger;
    private readonly string apiKey;
    
    public GeoCodingApi(ILogger<GeoCodingApi> logger)
    {
        _logger = logger;
        apiKey = "d00266d7b05eb74f62ad1714907c8af5";
    }

    public async Task<string> GetCoordinates(string city)
    {
        var url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit={1}&appid={apiKey}";
        
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            _logger.LogInformation($"Received data from API: {response}");
            if( response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
    }
}