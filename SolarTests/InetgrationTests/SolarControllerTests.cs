using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;


namespace SolarTests;
[Collection("Integration")]
public class SolarControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SolarControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task GetSolarData()
    {
        var app = new SolarWebApplicationFactory();
        var client = app.CreateClient();
        var city = "Budapest";
        var date = new DateTime(2025, 01, 01);
        var formattedDate = date.ToString("yyyy-MM-dd");

        var response = await client.GetAsync($"/api/Solar/SunriseSunset/{city}/{formattedDate}");
        
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