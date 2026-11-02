using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Booking
{
    private static int _currentId;
    public static Slot BookedSlot { get; }

    public Booking(Slot bookedSlot)
    {
        bookedSlot = bookedSlot;
    }
}

