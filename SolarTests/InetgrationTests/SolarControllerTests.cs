using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;


namespace SolarTests;
[Collection("Integration")]
public class SolarControllerTests
{

    [Fact]
    public async Task GetSolarData()
    {
        var app = new SolarWebApplicationFactory();
        var client = app.CreateClient();
        var city = "Budapest";
        var date = new DateTime(2025, 01, 01);

        var response = await client.GetAsync($"/api/Solar/SunriseSunset/{city}/{date}");

        response.EnsureSuccessStatusCode();

        var solarWatch = await response.Content.ReadFromJsonAsync<SolarWatch.SolarWatch>();

        Assert.NotNull(solarWatch);
        Assert.Equal(solarWatch.City, city);
        Assert.Equal(solarWatch.Date, date);
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
        Assert.Empty(solarResponse);
       
        
        
       
        
    }
}