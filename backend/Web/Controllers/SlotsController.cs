using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/slots")]
public class SlotsController : ControllerBase
{
    // PATCH: api/slots/{id}
    [HttpPatch("{id:int}")]
    public IActionResult UpdateSlot(int id) => NoContent();

    // DELETE: api/slots/{id}
    [HttpDelete("{id:int}")]
    public IActionResult DeleteSlot(int id) => Ok();

    // POST: api/slots/{id}/book
    [HttpPost("{id:int}/book")]
    public IActionResult BookSlot(int id) => Ok();
}