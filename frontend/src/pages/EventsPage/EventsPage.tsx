import { EventCard } from "../../components/EventCard/EventCard";
import type { Event } from '../../types/event'
import type { Slot } from "../../types/slot";
import styles from './EventsPage.module.css'

type Props = {
  events: Event[]
  slots: Slot[]
  bookedSlotIds: number[]
  onSelectEvent: (eventId: number) => void
}

export function EventsPage({ events, slots, bookedSlotIds, onSelectEvent }: Props) {
  return (
    <section className="page">
      <h1>Мероприятия</h1>
      <p className="muted">Всё к чему дали доступ по ссылке</p>
      <div className={`stack ${styles.list}`}>
        {events.length === 0 && <p className="empty">Пока нет мероприятий</p>}
        {events.map(event => {
          const eventSlots = slots.filter(slot => slot.eventId === event.id)
          const mySlot = eventSlots.find(slot => bookedSlotIds.includes(slot.id))

          return (
            <EventCard
              key={event.id}
              event={event}
              slots={eventSlots}
              bookedSlotId={mySlot?.id}
              onOpen={() => onSelectEvent(event.id)}
            />
          )
        })}
      </div>
    </section>
  )
}
