using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

class FullName
{
    public string Name { get; }
    public string Surname { get; }

    public FullName(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}
