using Domain.Repositories;
using SlotExam.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

class DeleteBookingService
{
    private IBookingRepository _bookings;
    private ISlotRepository _slots;

    public DeleteBookingService(IBookingRepository bookings, ISlotRepository slots)
    {
        _slots = slots;
        _bookings = bookings;
    }

    public async Task Handle(DeleteBookingCommand command, CancellationToken ct)
    {
        var booking = await _bookings.GetByIdAsync(command.bookingId, ct)
            ?? throw new ArgumentException($"Нет записа с id {command.bookingId}");
        var slot = await _slots.GetByIdAsync(booking.SlotId, ct)
            ?? throw new Exception();

        slot.CancelBooking();

        await _bookings.DeleteAsync(booking, ct);
    }
}
