using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Domain.Aggregates;
using Domain.ValueTypes;

namespace Application.Services;

class EditProfileCommandService
{
    private readonly IUserRepository _users;
    private readonly IGroupRepository _groups;

    public EditProfileCommandService(IUserRepository users, IGroupRepository groups)
    {
        _users = users;
        _groups = groups;
    }

    public async Task HandleAsync(EditProfileCommand command, CancellationToken ct)
    {
        var user = await _users.GetByIdAsync(command.userId, ct)
            ?? throw new KeyNotFoundException("Такого пользователя не существует");

        var fullName = new FullName(command.name, command.surname);

        var group = await _groups.GetByNameAsync(command.groupName, ct)
            ?? throw new KeyNotFoundException("Такой группы не существует");

        user.SetFullName(fullName);
        user.SetGroupId(group.Id);

        await _users.UpdateAsync(user, ct);
    }
}
