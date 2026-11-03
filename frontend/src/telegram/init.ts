import { init, initData, isTMA, miniApp, themeParams } from '@telegram-apps/sdk'

// This is client-side display data, not a server-authenticated profile.
export interface TelegramContext {
  mode: 'browser' | 'telegram' | 'unavailable'
  firstName: string | null
}

export function initializeTelegram(): TelegramContext {
  try {
    if (!isTMA()) {
      return { mode: 'browser', firstName: null }
    }

    const cleanup = init()
    if (import.meta.hot) import.meta.hot.dispose(cleanup)

    initData.restore()
    const user = initData.user()

    // SDK updates these CSS variables when Telegram's theme changes.
    themeParams.mountSync()
    const unbind = themeParams.bindCssVars()
    if (import.meta.hot) {
      import.meta.hot.dispose(() => {
        unbind()
        themeParams.unmount()
      })
    }

    miniApp.ready.ifAvailable()

    return { mode: 'telegram', firstName: user?.first_name ?? null }
  } catch {
    // An invalid launch must not leave the user with a blank screen.
    return { mode: 'unavailable', firstName: null }
  }
}
