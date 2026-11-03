export type EventKind = 'lab' | 'colloquium' | 'exam'

export type Event = {
  id: number
  kind: EventKind
  title: string
  dateLabel: string
  group: string
  teacher: string
}
