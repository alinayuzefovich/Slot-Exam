import type { Event, EventKind } from '../../types/event'
import type { Slot } from '../../types/slot'
import styles from './EventCard.module.css'

type Props = {
  event: Event
  slots: Slot[]
  bookedSlotId: number | undefined
  onOpen: () => void
}

const kindLabels: Record<EventKind, string> = {
  "lab": 'Лабораторная',
  "colloquium": 'Коллоквиум',
  "exam": 'Экзамен',
}

export function EventCard({ event, slots, bookedSlotId, onOpen }: Props) {
  const mySlot = slots.find(slot => slot.id === bookedSlotId)
  const hasFreePlace = slots.some(slot => slot.booked < slot.capacity)

  let status = 'Мест нет'
  if (slots.length === 0) status = 'Слоты пока не опубликованы'
  if (hasFreePlace) status = 'Есть свободные места'
  if (mySlot) status = `Вы записаны ${mySlot.timeLabel}`

  return (
    <button className={styles.card} type="button" onClick={onOpen}>
      <span className={styles.tag}>{kindLabels[event.kind]}</span>
      <strong>{event.title}</strong>
      <span className='muted'>{event.dateLabel} {event.group}</span>
      <span className={styles.status}>{status}</span>
    </button >
  )
}
