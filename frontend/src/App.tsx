import { useState } from 'react'
import { events } from './mocks/events'
import { initialSlots } from './mocks/slots'
import { EventsPage } from './pages/EventsPage/EventsPage'
import type { TelegramContext } from './telegram/init'

interface AppProps {
  telegram: TelegramContext
}

export default function App({ telegram }: AppProps) {
  const [isDebugEnabled, SetDebugEnabled] = useState(false)

  return (
    <main className="app-shell">
      <header className="app-header">
        <p>Привет, {telegram.firstName ?? 'гость'}!</p>
        <div className="debug-panel">
          <button onClick={() => SetDebugEnabled(value => !value)}>
            {isDebugEnabled ? 'Скрыть отладочную информацию' : 'Показать отладочную информацию'}
          </button>
          {isDebugEnabled &&
            <pre>
              {JSON.stringify(telegram.userInfo)}
            </pre>
          }
        </div>
      </header>
      <EventsPage
        events={events}
        slots={initialSlots}
        bookedSlotIds={[]}
        onSelectEvent={eventId => console.log('Открыть мероприятие', eventId)}
      />
    </main >
  )
}
