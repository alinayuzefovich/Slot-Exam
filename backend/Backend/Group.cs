using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

class Group
{
    private static int _currentId;
    public int Id { get; set; }
    public string Name { get; }

    public Group(string name)
    {
        Id = _currentId++;
        Name = name;
    }
}
