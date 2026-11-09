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
    Task AddAsync(Slot slot, CancellationToken ct);
    void Remove(Slot slot);
}
