using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IUserRepository: IRepository<User>
{
    Task<User?> GetByTelegramIdAsync(long telegramId, CancellationToken ct);
    Task UpdateAsync(User user, CancellationToken ct);
}
