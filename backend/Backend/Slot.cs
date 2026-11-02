using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

class Slot
{
    private static int _currentId;
    public int Id { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public Event Event { get; }
    public int CurrentCapacity { get; }
    public int MaxCapacity { get; }
    public bool IsFull => MaxCapacity == CurrentCapacity;
    public bool IsPast => DateTime.UtcNow > StartTime;

    public Slot(Event e, int capacity, DateTime startTime, DateTime endTime)
    {
        Id = _currentId++;
        MaxCapacity = capacity;
        StartTime = startTime;
        EndTime = endTime;
        Event = e;
    }
}
