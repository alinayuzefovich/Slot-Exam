using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EventDescription
{
    public string Title { get; }
    public string Description { get; }
    public string Type { get; }
    public int? DeadlineHours { get; }
    public Location Location { get; }

    public EventDescription(string title, string description, string type, Location location, int? deadlineHours=null)
    {
        Title = title;
        Description = description;
        Type = type;
        DeadlineHours = deadlineHours;
        Location = location;
    }
}
