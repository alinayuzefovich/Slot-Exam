using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IStudyEventRepository
{
    Task<StudyEvent?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(StudyEvent studyEvent, CancellationToken ct);
    void Remove(StudyEvent studyEvent);
}

