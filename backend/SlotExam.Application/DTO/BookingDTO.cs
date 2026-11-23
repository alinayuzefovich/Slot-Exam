using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record BookingDto(Guid id, Guid eventId, Guid slotId, BookingStatus status, DateTime startAt, DateTime endAt);
