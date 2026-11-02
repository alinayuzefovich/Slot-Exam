using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Booking
{
    private static int _currentId;
    public Slot BookedSlot { get; }
    public User Owner { get; }

    public Booking(User owner, Slot bookedSlot)
    {
        Owner = owner;
        BookedSlot = bookedSlot;
    }
}

