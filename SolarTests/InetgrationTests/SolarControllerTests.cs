using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace SolarTests;
[Collection("Integration")]
public class SolarControllerTests
{
   
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