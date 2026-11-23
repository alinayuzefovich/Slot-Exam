using Application.Converters;
using Application.DTO;
using Application.Querries;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class GetUserEventsService
{
    private IUserRepository _users;
    private ISlotRepository _slots;
    private IStudyEventRepository _events;

    public GetUserEventsService(IUserRepository users, ISlotRepository slots, IStudyEventRepository events)
    {
        _users = users;
        _slots = slots;
        _events = events;
    }

    public async Task<IEnumerable<ShortEventInfoDto>> Handle(GetUserEventsQuery query, CancellationToken ct)
    {
        var user = await _users.GetByIdAsync(query.userId, ct)
            ?? throw new ArgumentException($"Не существует юзера с id {query.userId}");
        var events = await _events.GetByGroupIdAsync(user.GroupId, ct);

        var result = new List<ShortEventInfoDto>();

        foreach (var e in events)
        {
            result.Add(e.ToShortEventInfoDto());
        }

        return result;
    }

}
