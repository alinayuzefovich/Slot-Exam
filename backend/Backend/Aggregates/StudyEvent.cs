using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates;

public class StudyEvent: AggregateRoot
{
    public EventDescription Description { get; }
    public List<Slot> Slots { get; }
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
        Slots = new List<Slot>();
    }

    public static StudyEvent CreateEvent(EventDescription description, int ownerId, Address address)
    {
        return new StudyEvent(Guid.NewGuid(), description, ownerId, address);
    }

    public void AddSlot(Slot slot)
    {
        if (slot.Location.Address != Address)
            throw new ArgumentException("Адрес слота и мероприятия должен совпадать");

        if (Status == StudyEventStatus.Cancelled)
            throw new Exception("Невозможно добавить слот к отменённому мероприятию");

        Slots.Add(slot);
    }
}

