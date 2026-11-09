using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BookingService
{
    private readonly IUserRepository users;
    private readonly ISlotRepository slots;
    private readonly IBookingRepository bookings;
    private readonly IStudyEventRepository studyEvents;

    public async Task BookSlot(Guid userId, Guid slotId, CancellationToken ct)
    {
        var user = await users.GetByIdAsync(userId, ct);
        var slot = await slots.GetByIdAsync(slotId, ct);
        var studyEvent = await studyEvents.GetByIdAsync(slot.StudyEventId, ct);

        var isPossibleToBook = studyEvent.Slots
            .Where(slot => slot.CurrentCapacity > 0)
            .SelectMany(slot => slot.Bookings)
            .Any(booking => booking.OwnerId == userId);

        if (!isPossibleToBook)
            throw new Exception("У пользователя уже есть бронь на данное мероприятие");

        var booking = slot.Book(userId);

        await bookings.AddAsync(booking, ct);
    }
}
