using Application.Querries;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers;


public class GetUserBookingsHandler
{
    private readonly IBookingRepository _bookings;
    private readonly ISlotRepository _slots;

    public GetUserBookingsHandler( IBookingRepository bookings, ISlotRepository slots)
    {
        _bookings = bookings;
        _slots = slots;
    }

    public async Task<IEnumerable<BookingDTO>> HandleAsync(GetUserBookingsQuery query, CancellationToken ct)
    {
        var bookings = await _bookings.GetByUserIdAsync(query.userId, ct);
        var result = new List<BookingDTO>();
        var slotIds = bookings.Select(booking => booking.SlotId).Distinct();
        var slots = await _slots.GetByIdsAsync(slotIds, ct);

        var slotsById = slots.ToDictionary(s => s.Id);

        foreach (var booking in bookings)
        {
            if (!slotsById.TryGetValue(booking.SlotId, out var slot))
                throw new KeyNotFoundException($"Не существует слота с id {booking.SlotId}");

            result.Add(new BookingDTO(
                booking.Id,
                slot.StudyEventId,
                booking.SlotId,
                booking.Status,
                slot.StartTime,
                slot.EndTime
                ));
        }

        return result;
    }

}