using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Aggregates;
using Application.Commands;

namespace Application.Services;

public class AuthTelegramUserCommandService
{
    private readonly IUserRepository _users;

    public AuthTelegramUserCommandService(IUserRepository users)
    {
        _users = users;
    }

    public async Task<User> HandleAsync(AuthTelegramUserCommand command, CancellationToken ct)
    {
        var user = await _users.GetByTelegramIdAsync(command.telegramId, ct);

        if (user is null)
        {
            user = User.CreateUser(command.telegramId);
            await _users.AddAsync(user, ct);
        }

        return user;
    }
}