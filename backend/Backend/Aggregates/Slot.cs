using Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates;

public class Slot: AggregateRoot
{
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public Guid StudyEventId { get; }
    public Location Location { get; }
    public List<Booking> Bookings { get; } 
    public int CurrentCapacity { get; private set; }
    public int MaxCapacity { get; }
    public bool IsFull => MaxCapacity == CurrentCapacity;
    public bool IsPast => DateTime.UtcNow > StartTime;

    private Slot(Guid id, Guid studyEventId, int capacity, DateTime startTime, DateTime endTime)
    {
        Id = id;
        MaxCapacity = capacity;
        StartTime = startTime;
        EndTime = endTime;
        StudyEventId = studyEventId;
        Bookings = new List<Booking>();
    }

    public static Slot CreateSlot(Guid studyEventId, int capacity, DateTime startTime, DateTime endTime)
    {
        if (startTime > DateTime.UtcNow)
            throw new ArgumentException("Время слота который вы пытаетесь создать уже прошло");

        if (capacity <= 0)
            throw new ArgumentException("Нельзя создать слот с нулевой вместимостью");

        return new Slot(Guid.NewGuid(), studyEventId, capacity, startTime, endTime);
    }

    public Booking Book(Guid userId)
    {
        if (IsFull)
            throw new ArgumentException("Невозможно записаться, слот уже заполнен");

        if (IsPast)
            throw new ArgumentException("Невозможно записаться, слот уже прошёл");

        return Booking.CreateBooking(userId, Id);
    }
}
