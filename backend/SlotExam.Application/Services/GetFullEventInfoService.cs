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

public class GetFullEventInfoService
{
    private IStudyEventRepository _events;
    private IBookingRepository _bookings;
    private IUserRepository _users;
    private ISlotRepository _slots;

    public GetFullEventInfoService(IStudyEventRepository events, IBookingRepository bookings, IUserRepository users, ISlotRepository slots)
    {
        _events = events;
        _bookings = bookings;
        _users = users;
        _slots = slots;
    }

    public async Task<FullEventInfoDto> Handle(GetFullEventInfoQuery query, CancellationToken ct)
    {
        var studyEvent = await _events.GetByIdAsync(query.eventId, ct)
            ?? throw new ArgumentException($"Не существует ивента с id {query.eventId}");
        var owner = await _users.GetByIdAsync(studyEvent.OwnerId, ct)
            ?? throw new ArgumentException($"Не существует пользователя с id {studyEvent.OwnerId}");
        var slots = await _slots.GetByEventIdAsync(query.eventId, ct);

        var totalFreeSlots = 0;

        foreach (var slot in slots)
        {
            totalFreeSlots += slot.MaxCapacity - slot.CurrentCapacity;
        }

        return studyEvent.ToFullEventInfoDto(owner, totalFreeSlots);
    }
}
