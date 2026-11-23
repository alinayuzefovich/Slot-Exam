using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Aggregates;
using Application.Commands;

namespace Application.Services;

public class BookSlotCommandService
{
    private readonly IUserRepository _users;
    private readonly ISlotRepository _slots;
    private readonly IBookingRepository _bookings;
    private readonly IStudyEventRepository _studyEvents;

    public BookSlotCommandService(
        IUserRepository users,
        ISlotRepository slots,
        IBookingRepository bookings,
        IStudyEventRepository studyEvents)
    {
        _users = users;
        _slots = slots;
        _bookings = bookings;
        _studyEvents = studyEvents;
    }

    public async Task HandleAsync(BookSlotCommand command, CancellationToken ct)
    {
        var slot = await _slots.GetByIdAsync(command.SlotId, ct)
            ?? throw new KeyNotFoundException("Слот не найден");

        var slots = await _slots.GetByEventIdAsync(slot.StudyEventId, ct);

        var bookingTasks = slots.Select(slot => _bookings.GetBySlotIdAsync(slot.Id, ct));
        var allBookings = await Task.WhenAll(bookingTasks);

        var hasAlreadyBooked = allBookings.SelectMany(c => c).Any(b => b != null && b.OwnerId == command.UserId);

        if (hasAlreadyBooked)
        {
            throw new InvalidOperationException("У пользователя уже есть бронь на данное мероприятие");
        }

        var booking = slot.Book(command.UserId);

        await _bookings.AddAsync(booking, ct);
    }
}