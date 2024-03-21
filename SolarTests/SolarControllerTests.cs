using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace SolarTests;

public class SolarControllerTests
{
    [Fact]
    public async Task  GetSolarWatch_User_Test()
    {
        var app = new SolarWebApplicationFactory();
        var requestCity = "Budapest";
        var requestDate = new DateTime(2022, 1, 3);
        
        var client = app.CreateClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("TestScheme");
        
        var response = await client.GetAsync($"api/Solar/SunriseSunset/{requestCity}/{requestDate}");
        
        response.EnsureSuccessStatusCode();

        var solarResponse = await response.Content.ReadFromJsonAsync<SolarWatch.SolarWatch>();
        
        Assert.Equal(requestCity, solarResponse.City);
        Assert.Equal(requestDate, solarResponse.Date);
        
    }
    
    [Fact]
    public async Task GetAllSolarWatch_Admin_Test()
    {
        var app = new SolarWebApplicationFactory();
        
        
        var client = app.CreateClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("TestAdminScheme");
        
        var response = await client.GetAsync($"api/Solar/SunriseSunset/all");
        
        response.EnsureSuccessStatusCode();

        var solarResponse = await response.Content.ReadFromJsonAsync<List<SolarWatch.SolarWatch>>();
        Assert.NotNull(solarResponse);
        Assert.Equal(2, solarResponse.Count);
        Assert.Equal("Paris", solarResponse[0].City);
        
        
       
        
    }
}