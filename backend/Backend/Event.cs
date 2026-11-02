using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

class Event
{
    private static int _currentId;

    public int Id { get; }
    public EventDescription Description { get; }
    public Slot Slots { get; }
    public bool IsActive { get; }
    public int OwnerId { get; }


    public Event(EventDescription description, int ownerId)
    {
        Id = _currentId++;
        Description = description;
        IsActive = true;
        OwnerId = ownerId;
    }
}

