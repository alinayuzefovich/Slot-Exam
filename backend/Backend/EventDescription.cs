using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EventDescription
{
    public string Title { get; }
    public string Type { get; }
    public int DeadlineHours { get; }

    public EventDescription(string title, string type, int deadlineHours)
    {
        Title = title;
        Type = type;
        DeadlineHours = deadlineHours;
    }
}
