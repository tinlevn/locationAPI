namespace locationApi.Controllers;
using locationApi.Model;
using locationApi.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/locations")]
public class LocationController : ControllerBase
{
    private readonly LocationRepository _repository;

    public LocationController(LocationRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public Task<List<Location>> GetAll()
    {
        return _repository.GetAllLocation();
    }

    [HttpGet("{locationNumber}")]
    public ActionResult<Location> GetByLocationNumber(string locationNumber)
    {
        var location = _repository.GetByLocationNumber(locationNumber);
        if (location == null)
        {
            return NotFound();
        }
        return location;
    }

    [HttpPost]
    public ActionResult<Location> Create(Location location)
    {
        _repository.Create(location);
        return CreatedAtAction(nameof(GetByLocationNumber), new { locationNumber = location.LocationNumber }, location);
    }

    [HttpPut("{locationNumber}")]
    public IActionResult Update(string locationNumber, Location location)
    {
        if (locationNumber != location.LocationNumber)
        {
            return BadRequest();
        }

        _repository.Update(location);
        return NoContent();
    }

    [HttpDelete("{locationNumber}")]
    public IActionResult Delete(string locationNumber)
    {
        _repository.Delete(locationNumber);
        return NoContent();
    }
}