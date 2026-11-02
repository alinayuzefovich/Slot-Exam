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
    public DateTime Time { get; }
    public Event Event { get; }
    public bool IsBooked { get; }
    public int Capacity { get; }

    public Slot(Event e, int capacity, DateTime time)
    {
        Id = _currentId++;
        Capacity = capacity;
        Time = time;
        Event = e;
    }
}
