import { events } from './mocks/events'
import { initialSlots } from './mocks/slots'
import { EventsPage } from './pages/EventsPage/EventsPage'
import type { TelegramContext } from './telegram/init'

interface AppProps {
  telegram: TelegramContext
}

export default function App({ telegram }: AppProps) {
  return (
    <main className="app-shell">
      <header className="app-header">
        <p>Привет, {telegram.firstName ?? 'гость'}!</p>
      </header>
      <EventsPage
        events={events}
        slots={initialSlots}
        bookedSlotIds={[]}
        onSelectEvent={eventId => console.log('Открыть мероприятие', eventId)}
      />
    </main>
  )
}
