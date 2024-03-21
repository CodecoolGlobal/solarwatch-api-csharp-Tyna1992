using System.Data.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SolarWatch.Data;

namespace SolarTests;

internal class SolarWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<GeoCoordinatesContext>));
            services.RemoveAll(typeof(DbContextOptions<UserContext>));
            var connectionString = "Server=localhost,1433;Database=SolarWatch_Test;User Id=sa;Password=Zakuro19920120;Encrypt=false;";
            Console.WriteLine(connectionString);
            services.AddDbContext<GeoCoordinatesContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddAuthentication("TestScheme")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("TestScheme", options => { });
            
            services.AddAuthentication("TestAdminScheme")
                .AddScheme<AuthenticationSchemeOptions,TestAuthHandler >("TestAdminScheme", options => { });
            
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var geoContext = scope.ServiceProvider.GetRequiredService<GeoCoordinatesContext>();
                var userContext = scope.ServiceProvider.GetRequiredService<UserContext>();

                geoContext.Database.EnsureCreated();
                userContext.Database.Migrate();
                userContext.Database.EnsureCreated();

                
            }
        });
    }

    
    
}