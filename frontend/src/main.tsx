import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App'
import { initializeTelegram } from './telegram/init'
import './index.css'

// SDK initialization is a side effect: do it once, outside React rendering.
const telegram = initializeTelegram()

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App telegram={telegram} />
  </StrictMode>,
)
