using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO;

public record FullEventInfoDto(Guid id, StudyEventStatus status, string title, string type, string description,
    string address, int cancelDeadlineHours, Guid organizerId, string organizerName, int freeSlotsCount);