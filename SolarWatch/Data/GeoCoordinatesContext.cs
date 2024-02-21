using SolarWatch.Model;

namespace SolarWatch.Data;
using Microsoft.EntityFrameworkCore;

public class GeoCoordinatesContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<SunriseSunset> SunriseSunsets { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=SolarWatch;User Id=sa;Password=Zakuro19920120;Encrypt=false;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<City>().OwnsOne(c => c.Coordinates);
        builder.Entity<SunriseSunset>()
            .HasOne(ss => ss.City)
            .WithOne(c => c.SunriseSunset)
            .HasForeignKey<City>(c => c.SunriseSunsetId); // Use SunriseSunsetId from City as the foreign key

        builder.Entity<City>()
            .HasIndex(city => city.Name).IsUnique();
        
        
    }
}