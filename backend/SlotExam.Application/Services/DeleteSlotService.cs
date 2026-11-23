using Application.Commands;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class DeleteSlotService
{
    private ISlotRepository _slots;
    private IBookingRepository _bookings;

    public DeleteSlotService(ISlotRepository slots, IBookingRepository bookings)
    {
        _slots = slots;
        _bookings = bookings;
    }

    public async Task Handle(DeleteSlotCommand command, CancellationToken ct)
    {
        var slot = await _slots.GetByIdAsync(command.slotId, ct)
            ?? throw new ArgumentNullException($"Не существует слота с id {command.slotId}");
        
        var bookings = await _bookings.GetBySlotIdAsync(command.slotId, ct);
        
        foreach (var booking in bookings)
        {
            slot.CancelBooking();
            await _bookings.DeleteAsync(booking, ct);
        }

        await _slots.DeleteAsync(slot, ct);
    }
}

