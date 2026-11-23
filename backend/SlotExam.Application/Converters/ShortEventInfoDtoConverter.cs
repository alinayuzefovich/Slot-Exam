using Application.DTO;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters;

public static class ShortEventInfoDtoConverter
{
    public static ShortEventInfoDto ToShortEventInfoDto(this StudyEvent e, User owner, User user, IEnumerable<Slot> slots, IEnumerable<Booking> bookings)
    {
        var description = e.Description;
        var nextSlot = slots.MinBy(slot => slot.StartTime);
        var isOwnedByUser = slots.Any(slot => slot.)


        return new ShortEventInfoDto(e.Id,
            description.Title,
            description.Type,
            e.Status,
            owner.GetFullName(),
            nextSlot.EndTime,
            )
    }
}
