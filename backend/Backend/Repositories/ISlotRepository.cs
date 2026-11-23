using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface ISlotRepository: IRepository<Slot>
{
    Task<IEnumerable<Slot>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct);
    Task<IEnumerable<Slot>> GetByEventIdAsync(Guid eventId, CancellationToken ct);
}
