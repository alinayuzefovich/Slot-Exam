using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Booking: AggregateRoot
{
    public Guid SlotId { get; private set; }
    public Guid OwnerId { get; private set; }
    public BookingStatus Status { get; private set; }

    private Booking(Guid id, Guid ownerId, Guid slotId)
    {
        Id = id;
        OwnerId = ownerId;
        SlotId = slotId;
    }

    public static Booking CreateBooking(Guid ownerId, Guid slotId)
    {
        return new Booking(Guid.NewGuid(), ownerId, slotId);
    }
}

