using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO;

public record ShortEventInfoDto(Guid eventId, string title, string type, StudyEventStatus status, string organizerName, DateTime nextSlotAt, bool isBooked, int freeSlotsCount);
