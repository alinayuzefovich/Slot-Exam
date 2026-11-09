using Microsoft.AspNetCore.Mvc;
using Web.Contracts;
using Web.Mappers;

namespace Web.Controllers;

[ApiController]
[Route("api/me")]
public class UsersController : ControllerBase
{
    // GET: api/me
    [HttpGet]
    public IActionResult GetMyProfile()
    {
        // Возвращаем профиль пользователя
        return Ok();
    }

    // PATCH: api/me
    [HttpPatch]
    public IActionResult UpdateMyProfile()
    {
        // Обновление полей профиля (fullName, groupName, notificationsEnabled)
        return NoContent();
    }

    // GET: api/me/events
    [HttpGet("events")]
    public IActionResult GetMyEvents()
    {
        // Мероприятия организатора
        return Ok(new List<object>());
    }

    // GET: api/me/bookings
    [HttpGet("bookings")]
    public IActionResult GetMyBookings()
    {
        // Записи пользователя
        return Ok(new List<object>());
    }
}