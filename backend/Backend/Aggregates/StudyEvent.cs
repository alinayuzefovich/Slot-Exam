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
    public Guid OwnerId { get; }
    public List<Guid> GroupIds { get; }
    public Address Address { get; }


    private StudyEvent(Guid id, EventDescription description, Guid ownerId, Address address, List<Guid> attachedGroupsIds)
    {
        Id = id;
        Description = description;
        Status = StudyEventStatus.Draft;
        OwnerId = ownerId;
        Address = address;
        GroupIds = attachedGroupsIds;
    }

    public static StudyEvent CreateEvent(EventDescription description, Guid ownerId, Address address, List<Guid> attachedGroupsIds = null)
    {
        if (attachedGroupsIds != null)
            return new StudyEvent(Guid.NewGuid(), description, ownerId, address, attachedGroupsIds);
        else
            return new StudyEvent(Guid.NewGuid(), description, ownerId, address, new List<Guid>());
    }

    public Slot AddSlot(int capacity, DateTime startTime, DateTime endTime, string classRoom, List<Guid> attachedGroupsIds)
    {
        var slot = Slot.CreateSlot(Id, capacity, startTime, endTime, new Location(Address, classRoom));

        if (Status == StudyEventStatus.Cancelled)
            throw new Exception("Невозможно добавить слот к отменённому мероприятию");

        AddDomainEvent(new SlotAddedEvent(slot.Id, Id, DateTime.UtcNow));

        return slot;
    }
}

