using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    // DELETE: api/bookings/{id}
    [HttpDelete("{id:int}")]
    public IActionResult CancelBooking(int id) => NoContent();

    // POST: api/bookings/{id}/reschedule
    [HttpPost("{id:int}/reschedule")]
    public IActionResult RescheduleBooking(int id, [FromBody] int newSlotId) => Ok();
}