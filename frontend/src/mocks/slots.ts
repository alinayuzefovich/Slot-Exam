import type { Slot } from '../types/slot'

export const initialSlots: Slot[] = [
  { id: 1, eventId: 1, dayLabel: '12 ноября', timeLabel: '10:00–10:15', capacity: 3, booked: 3 },
  { id: 2, eventId: 1, dayLabel: '12 ноября', timeLabel: '10:20–10:35', capacity: 3, booked: 0 },
  { id: 3, eventId: 1, dayLabel: '12 ноября', timeLabel: '10:40–10:55', capacity: 3, booked: 2 },
  { id: 4, eventId: 1, dayLabel: '13 ноября', timeLabel: '14:00–14:15', capacity: 3, booked: 1 },
  { id: 5, eventId: 2, dayLabel: '16 ноября', timeLabel: '09:40–09:55', capacity: 2, booked: 1 },
  { id: 6, eventId: 3, dayLabel: '20 декабря', timeLabel: '10:00–10:20', capacity: 3, booked: 3 },
]
