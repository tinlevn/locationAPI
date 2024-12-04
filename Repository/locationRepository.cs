using locationApi.Model;
using Microsoft.EntityFrameworkCore;

namespace locationApi.Repository;
public class LocationRepository
{
    private readonly LocationsDbContext _context;
    public LocationRepository(LocationsDbContext context) {
        _context = context;
    }

    public async Task<List<Location>> GetAllLocation()
    {
        var allLocations = await _context.Locations.ToListAsync();
        return allLocations;
    }

    public  Location GetByLocationNumber(string locationNumber)
    {
        return  _context.Locations.FirstOrDefault(l => l.LocationNumber == locationNumber);
    }

    public async void Create(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
    }

    public async void Update(Location location)
    {
        var existing = GetByLocationNumber(location.LocationNumber);
        //Possible try catch block for error handling here
        if (existing != null)
        {
            existing.Building = location.Building;
            existing.LocationName = location.LocationName;
            existing.Area = location.Area;
        }
        await _context.SaveChangesAsync();
    }

    public void Delete(string locationNumber)
    {
        var existing = GetByLocationNumber(locationNumber);
        if (existing != null)
        {
            _context.Remove(existing);
        }
        _context.SaveChangesAsync();
    }
}