using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEvents;

public record BookingCancelledEvent(Guid slotId, DateTime CreatedAt): IDomainEvent;

