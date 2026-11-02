using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Address
{
    public string City { get; }
    public string Street { get; }
    public string HouseNumber { get; }

    public Address(string city, string street, string houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public override string ToString()
    {
        return $"г. {City}, ул. {Street}, д. {HouseNumber}";
    }
}
