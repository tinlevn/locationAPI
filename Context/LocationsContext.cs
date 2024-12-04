using locationApi.Model;
using Microsoft.EntityFrameworkCore;

public class LocationsDbContext : DbContext
{
    public LocationsDbContext(DbContextOptions<LocationsDbContext> options)
        : base(options)
    {  
    }
     public DbSet<Location> Locations { get; set; }
}