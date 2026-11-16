using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface ISlotRepository
{
    Task<Slot?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<Slot>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct);
    Task<IEnumerable<Slot>> GetByEventIdAsync(Guid eventId, CancellationToken ct);
    Task AddAsync(Slot slot, CancellationToken ct);
    void Remove(Slot slot);
}
