using Application.Querries;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;


public class GetUserBookingsService
{
    private readonly IBookingRepository _bookings;
    private readonly ISlotRepository _slots;

    public GetUserBookingsService(IBookingRepository bookings, ISlotRepository slots)
    {
        _bookings = bookings;
        _slots = slots;
    }

    public async Task<IEnumerable<BookingDto>> HandleAsync(GetUserBookingsQuery query, CancellationToken ct)
    {
        var bookings = await _bookings.GetByUserIdAsync(query.userId, ct);
        var result = new List<BookingDto>();
        var slotIds = bookings.Select(booking => booking.SlotId).Distinct();
        var slots = await _slots.GetByIdsAsync(slotIds, ct);

        var slotsById = slots.ToDictionary(s => s.Id);

        foreach (var booking in bookings)
        {
            if (!slotsById.TryGetValue(booking.SlotId, out var slot))
                throw new KeyNotFoundException($"Не существует слота с id {booking.SlotId}");

            result.Add(new BookingDto(
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