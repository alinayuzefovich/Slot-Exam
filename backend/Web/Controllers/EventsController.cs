using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    // GET: api/events
    [HttpGet]
    public IActionResult GetEvents() => Ok(new List<object>());

    // POST: api/events
    [HttpPost]
    public IActionResult CreateEvent() => Ok();

    // GET: api/events/{id}
    [HttpGet("{id:int}")]
    public IActionResult GetEventById(int id) => Ok();

    // PATCH: api/events/{id}
    [HttpPatch("{id:int}")]
    public IActionResult UpdateEvent(int id) => NoContent();

    // POST: api/events/join
    [HttpPost("join")]
    public IActionResult JoinEvent([FromBody] string inviteCode) => Ok();

    // POST: api/events/{id}/publish
    [HttpPost("{id:int}/publish")]
    public IActionResult PublishEvent(int id) => Ok();

    // POST: api/events/{id}/cancel
    [HttpPost("{id:int}/cancel")]
    public IActionResult CancelEvent(int id) => NoContent();

    // GET: api/events/{id}/slots
    [HttpGet("{id:int}/slots")]
    public IActionResult GetEventSlots(int id) => Ok(new List<object>());

    // POST: api/events/{id}/slots
    [HttpPost("{id:int}/slots")]
    public IActionResult AddEventSlots(int id) => Ok();

    // POST: api/events/slots/preview
    [HttpPost("slots/preview")]
    public IActionResult PreviewSlots() => Ok();

    // GET: api/events/{id}/bookings
    [HttpGet("{id:int}/bookings")]
    public IActionResult GetEventBookings(int id) => Ok(new List<object>());
}