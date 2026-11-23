using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggregates;
using Domain.Entities;

namespace Domain.Repositories;

public interface IGroupRepository: IRepository<Group>
{
    Task<Group?> GetByNameAsync(string name, CancellationToken ct);
}
