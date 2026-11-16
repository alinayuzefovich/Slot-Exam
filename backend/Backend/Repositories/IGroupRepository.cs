using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggregates;
using Domain.Entities;

namespace Domain.Repositories;

public interface IGroupRepository
{
    Task<Group?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<Group?> GetByNameAsync(string name, CancellationToken ct);
    Task AddAsync(Group group, CancellationToken ct);
    void Remove(Group group);
}
