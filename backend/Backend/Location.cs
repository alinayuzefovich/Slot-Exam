using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

class Location
{
    public Address Address { get; }
    public string ClassRoom { get; }

    public Location (Address address, string classRoom)
    {
        Address = address;
        ClassRoom = classRoom;
    }

    public override string ToString()
    {
        return Address.ToString() + $", ауд. {ClassRoom}";
    }
}
