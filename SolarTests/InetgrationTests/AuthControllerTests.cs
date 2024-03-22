using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using SolarWatch.Contracts;
using SolarWatch.Services.Authentication;

namespace SolarTests;
[Collection("Integration")]
public class AuthControllerTests
{
    [Fact]
    public async Task RegisterUser_Test()
    {
        var app = new SolarWebApplicationFactory();
        var client = app.CreateClient();
        var request = new RegistrationRequest(
            Email: "testUser@test.com",
            Username: "testUser",
            Password: "test123"
            );
        
        var response = await client.PostAsJsonAsync("api/Auth/Register", request);
        
        response.EnsureSuccessStatusCode();
        
        var registrationResponse = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
        
        Assert.Equal(request.Email, registrationResponse.Email);
        Assert.Equal(request.Username, registrationResponse.UserName);
        
        
    }

    [Fact]
    public async Task LoginAdmin_Test_Success()
    {
        var app = new SolarWebApplicationFactory();
        var client = app.CreateClient();
        var request = new AuthRequest(
            Email: "admin@admin.com",
            Password: "admin123"
            );
       var response = await client.PostAsJsonAsync("api/Auth/Login", request);
        
        response.EnsureSuccessStatusCode();
        
        var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
        
        Assert.Equal(request.Email, authResponse.Email);
        Assert.Equal("admin", authResponse.UserName);     
    }
    
    
    [Fact]
    public async Task LoginUser_Test_InvalidCredentials()
    {
        var app = new SolarWebApplicationFactory();
        var client = app.CreateClient();
        var request = new AuthRequest(
            Email: "testUser@test.com",
            Password: "test1235"
        );
        var response = await client.PostAsJsonAsync("api/Auth/Login", request);
        
        Assert.Equal(StatusCodes.Status400BadRequest, (int)response.StatusCode);
        
        
    }
}