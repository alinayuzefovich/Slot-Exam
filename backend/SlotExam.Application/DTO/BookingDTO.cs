using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record BookingDTO(Guid id, Guid eventId, Guid slotId, BookingStatus status, DateTime startTime, DateTime endTime);
