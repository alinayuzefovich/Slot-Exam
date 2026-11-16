using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Group: Entity
{
    public string Name { get; }

    private Group(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Group CreateGroup(string name)
    {
        return new Group(Guid.NewGuid(), name);
    }
}
