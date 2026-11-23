using Application.DTO;
using Application.Querries;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters;

public static class FullEventInfoDtoConverter
{
    public static FullEventInfoDto ToFullEventInfoDto(this StudyEvent studyEvent, User owner, int freeSlotsCount)
    {
        var description = studyEvent.Description;

        return new FullEventInfoDto(studyEvent.Id,
            studyEvent.Status,
            description.Title,
            description.Type,
            description.Description,
            description.Location.GetAddress(),
            description.DeadlineHours,
            owner.Id,
            owner.GetFullName(),
            freeSlotsCount
            );
    }
}