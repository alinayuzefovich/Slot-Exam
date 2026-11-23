using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IStudyEventRepository: IRepository<StudyEvent>
{
    Task<IEnumerable<StudyEvent>> GetByGroupIdAsync(Guid groupIds, CancellationToken ct);
}

