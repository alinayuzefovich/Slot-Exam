import type { Event } from "../types/event"

export const events: Event[] = [
  {
    id: 1,
    kind: 'lab',
    title: 'Защита ЛР №3. Базы данных',
    dateLabel: '12-13 ноября',
    group: "ФИИТ-201",
    teacher: 'Иванов И. И.',
  },
  {
    id: 2,
    kind: 'colloquium',
    title: 'Алгоритмы и структуры данных',
    dateLabel: '16 ноября',
    group: 'ФИИТ-201',
    teacher: 'Петров П. П.',
  },
  {
    id: 3,
    kind: 'exam',
    title: 'Математический анализ',
    dateLabel: '20 декабря',
    group: 'ФИИТ-201',
    teacher: 'Сидорова А. А.',
  },
]
