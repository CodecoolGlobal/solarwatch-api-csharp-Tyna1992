using SolarWatch.Model;

namespace SolarWatch.Data;
using Microsoft.EntityFrameworkCore;

public class GeoCoordinatesContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<SunriseSunset> SunriseSunsets { get; set; }
    
    
    public GeoCoordinatesContext(DbContextOptions<GeoCoordinatesContext> options) : base(options)
    {
    }
    
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<City>().OwnsOne(c => c.Coordinates);
        builder.Entity<SunriseSunset>()
            .HasOne(ss => ss.City)
            .WithOne(c => c.SunriseSunset)
            .HasForeignKey<City>(c => c.SunriseSunsetId); 

        builder.Entity<City>()
            .HasIndex(city => city.Name).IsUnique();
        
        
    }
}