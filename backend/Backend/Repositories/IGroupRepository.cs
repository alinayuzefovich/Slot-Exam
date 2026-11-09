using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IGroupRepository
{
    Task<Group?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<Group?> GetByNameAsync(string name, CancellationToken ct);
    Task AddAsync(Group group, CancellationToken ct);
    void Remove(Group group);
}
