using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IBookingRepository: IRepository<Booking>
{
    Task<IEnumerable<Booking>> GetByIdsAsync(Guid ids, CancellationToken ct);
    Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId, CancellationToken ct);
    Task<IEnumerable<Booking>> GetBySlotIdAsync(Guid slotId, CancellationToken ct);
}
