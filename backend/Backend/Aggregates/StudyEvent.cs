using Domain.DomainEvents;
using Domain.Enums;
using Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates;

public class StudyEvent: AggregateRoot
{
    public EventDescription Description { get; }
    public StudyEventStatus Status { get; private set; }
    public int OwnerId { get; }
    public Address Address { get; }


    private StudyEvent(Guid id, EventDescription description, int ownerId, Address address)
    {
        Id = id;
        Description = description;
        Status = StudyEventStatus.Draft;
        OwnerId = ownerId;
        Address = address;
    }

    public static StudyEvent CreateEvent(EventDescription description, int ownerId, Address address)
    {
        return new StudyEvent(Guid.NewGuid(), description, ownerId, address);
    }

    public Slot AddSlot(int capacity, DateTime startTime, DateTime endTime, string classRoom)
    {
        var slot = Slot.CreateSlot(Id, capacity, startTime, endTime, new Location(Address, classRoom));

        if (Status == StudyEventStatus.Cancelled)
            throw new Exception("Невозможно добавить слот к отменённому мероприятию");

        AddDomainEvent(new SlotAddedEvent(slot.Id, Id, DateTime.UtcNow));

        return slot;
    }
}

