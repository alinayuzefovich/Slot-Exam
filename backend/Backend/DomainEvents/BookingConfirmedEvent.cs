using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEvents;

public record BookingConfirmedEvent(Guid BookingId, Guid SlotId, Guid UserId, DateTime CreatedAt) : IDomainEvent;
